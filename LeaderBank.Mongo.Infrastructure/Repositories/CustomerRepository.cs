﻿using AutoMapper;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Entities.Wrappers.CustomerComplete;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IMongoCollection<CustomerEntity> customerCollection;
        private readonly IMongoCollection<AccountEntity> accountCollection;
        private readonly IMongoCollection<CardEntity> cardCollection;
        private readonly IMongoCollection<TransactionEntity> transactionCollection;
        private readonly IMapper _mapper;
        public CustomerRepository(IContext context, IMapper mapper)
        {
            this.customerCollection = context.Customers;
            this.accountCollection = context.Accounts;
            this.cardCollection = context.Cards;
            this.transactionCollection = context.Transactions;
            _mapper = mapper;
        }
        public async Task<List<Customer>> GetAllCustomersAsync()
        {

            var filter = Builders<CustomerEntity>.Filter.Eq(c => c.State, true);
            var customer = await customerCollection.FindAsync(filter);
            var listCustomer = customer.ToEnumerable().Select(client => _mapper.Map<Customer>(client)).ToList();

            return listCustomer;
        }

        public async Task<CustomerComplete> GetCustomerCompleteByIdAsync(string id)
        {
            var customer = await customerCollection.Find(c => c.Customer_Id == id).FirstOrDefaultAsync();
            var customerComplete = _mapper.Map<CustomerComplete>(customer);

            var accounts = accountCollection.Aggregate()
                .Match(a => a.Id_Customer == id)
                .Lookup<AccountEntity, TransactionEntity, AccountCompleteEntity>(transactionCollection, a => a.Account_Id, 
                        t => t.Id_Account, (AccountCompleteEntity ac) => ac.Transactions)
                .ToList();

            foreach (var account in accounts)
            {
                foreach (var transaction in account.Transactions)
                {
                    _mapper.Map<Transaction>(transaction);
                }
                _mapper.Map<AccountComplete>(account);
                var card = await cardCollection.Find(c => c.Card_Id == account.Id_Card).FirstOrDefaultAsync();
                _mapper.Map<Card>(card);
                account.Card = card;
            }

            customerComplete.Accounts = _mapper.Map<List<AccountComplete>>(accounts);
            return customerComplete;
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            var customerSave = _mapper.Map<CustomerEntity>(customer);
            await customerCollection.InsertOneAsync(customerSave);
            return customer;
        }
    }
}