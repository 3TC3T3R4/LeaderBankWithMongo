using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Infrastructure
{
    public class Context : IContext
    {
        private readonly IMongoDatabase _database;

        public Context(string stringConnection, string DBname)
        {
            MongoClient cliente = new MongoClient(stringConnection);
            _database = cliente.GetDatabase(DBname);
        }

        public IMongoCollection<CustomerEntity> Customer => _database.GetCollection<CustomerEntity>("customers");

        public IMongoCollection<AccountEntity> Account => _database.GetCollection<AccountEntity>("accounts");

        public IMongoCollection<CardEntity> Card => _database.GetCollection<CardEntity>("cards");

        //public IMongoCollection<TransactionEnitity> Transaction => _database.GetCollection<TransactionEnitity>("transactions");
    }
}