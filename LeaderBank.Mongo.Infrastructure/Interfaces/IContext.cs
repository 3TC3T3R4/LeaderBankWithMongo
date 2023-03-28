using LeaderBank.Mongo.Infrastructure.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Infrastructure.Interfaces
{
    public interface IContext
    {

        public IMongoCollection<CustomerEntity> Customer { get; }
        public IMongoCollection<AccountEntity> Account { get; }
        public IMongoCollection<CardEntity> Card { get; }
        public IMongoCollection<TransactionEnitity> Transaction { get; }

       // public IMongoCollection<AdvisorEntity> Client { get; }



    }
}
