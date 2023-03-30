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
        private readonly IMongoCollection<AccountEntity> accountCollection;
        private readonly IMapper _mapper;

        public TransactionRepository(IContext context, IMapper mapper)
        {
            transactionCollection = context.Transactions;
            accountCollection = context.Accounts;
            _mapper = mapper;
        }

        public async Task<NewTransaction> CreateTransactionAsync(Transaction transaction)
        {
            //verify that account exist
            var accounts = await accountCollection.FindAsync(a => a.Account_Id == transaction.Id_Account);
            var associatedAccount = accounts.FirstOrDefault() ?? throw new Exception("Account not found.");

            //set values to transaction
            Transaction.SetDetailsTransaction(transaction);
            Transaction.CalculateBalances(transaction, _mapper.Map<Account>(associatedAccount));
            Transaction.Validate(transaction);

            //set and save new balance on account
            associatedAccount.Balance = transaction.FinalBalance;
            await accountCollection.ReplaceOneAsync(a => a.Account_Id == associatedAccount.Account_Id, associatedAccount);

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
