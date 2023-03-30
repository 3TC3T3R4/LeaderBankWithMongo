using MongoDB.Bson.Serialization.Attributes;

namespace LeaderBank.Mongo.Infrastructure.Entities.Wrappers.CustomerComplete
{
    public class AccountCompleteEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//CAMELCASE
        public string Account_Id { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id_Customer { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id_Card { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id_Advisor { get; set; }

        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public decimal ManagementCost { get; set; }
        public bool AccountState { get; set; }
        public CardEntity Card { get; set; }
        public List<TransactionEntity> Transactions { get; set; }
    }
}
