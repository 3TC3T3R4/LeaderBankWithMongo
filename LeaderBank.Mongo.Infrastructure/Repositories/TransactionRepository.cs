using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMongoCollection<TransactionEntity> transactionCollection;
        private readonly IMapper _mapper;

        public TransactionRepository(IContext context, IMapper mapper)
        {
            transactionCollection = context.Transactions;
            _mapper = mapper;
        }

        public async Task<NewTransaction> CreateTransactionAsync(Transaction transaction)
        {
            Transaction.SetDetailsTransaction(transaction);
            Transaction.Validate(transaction);
            var transactionToCreate = _mapper.Map<TransactionEntity>(transaction);
            await transactionCollection.InsertOneAsync(transactionToCreate);
            return _mapper.Map<NewTransaction>(transaction);
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            var transactions = await transactionCollection.FindAsync(t => t.TransactionState == true);
            var transactionsList = _mapper.Map<List<Transaction>>(transactions.ToList());
            if (transactionsList.Count == 0)
            {
                throw new ArgumentException("There aren't transactions to show.");
            }
            return transactionsList;
        }
    }
}
