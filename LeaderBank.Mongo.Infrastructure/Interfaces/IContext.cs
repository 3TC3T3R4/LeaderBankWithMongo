using LeaderBank.Mongo.Infrastructure.Entities;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Interfaces
{
    public interface IContext
    {
        public IMongoCollection<CustomerEntity> Customers { get; }
        public IMongoCollection<AccountEntity> Accounts { get; }
        public IMongoCollection<CardEntity> Cards { get; }
        public IMongoCollection<TransactionEntity> Transactions { get; }
        public IMongoCollection<AdvisorEntity> Advisors { get; }
    }
}
