using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure
{
    public class Context : IContext
    {
        private readonly IMongoDatabase _database;

        public Context(string stringConnection, string DBname)
        {
            MongoClient cliente = new(stringConnection);
            _database = cliente.GetDatabase(DBname);
        }

        public IMongoCollection<CustomerEntity> Customers => _database.GetCollection<CustomerEntity>("Customers");

        public IMongoCollection<AccountEntity> Accounts => _database.GetCollection<AccountEntity>("Accounts");

        public IMongoCollection<CardEntity> Cards => _database.GetCollection<CardEntity>("Cards");

        public IMongoCollection<TransactionEntity> Transactions => _database.GetCollection<TransactionEntity>("Transactions");

        public IMongoCollection<AdvisorEntity> Advisors => _database.GetCollection<AdvisorEntity>("Advisors");
    }
}