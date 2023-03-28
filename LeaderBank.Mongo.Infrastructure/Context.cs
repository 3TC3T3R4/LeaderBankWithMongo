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

        public IMongoCollection<CustomerEntity> Customer => _database.GetCollection<CustomerEntity>("Customers");

        public IMongoCollection<AccountEntity> Account => _database.GetCollection<AccountEntity>("Accounts");

        public IMongoCollection<CardEntity> Card => _database.GetCollection<CardEntity>("Cards");

        public IMongoCollection<TransactionEnitity> Transaction => _database.GetCollection<TransactionEnitity>("Transactions");

        public IMongoCollection<AdvisorEntity> Advisor => _database.GetCollection<AdvisorEntity>("Advisors");
    }
}