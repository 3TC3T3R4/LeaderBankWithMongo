using LeaderBank.Mongo.Infrastructure.Entities;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Interfaces
{
    public interface IContext
    {
        public IMongoCollection<CustomerEntity> Customer { get; }
        public IMongoCollection<AccountEntity> Account { get; }
        public IMongoCollection<CardEntity> Card { get; }
        public IMongoCollection<TransactionEnitity> Transaction { get; }
        public IMongoCollection<AdvisorEntity> Advisor { get; }
    }
}
