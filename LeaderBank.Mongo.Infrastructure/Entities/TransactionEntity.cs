using MongoDB.Bson.Serialization.Attributes;

namespace LeaderBank.Mongo.Infrastructure.Entities
{
    public class TransactionEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Transaction_Id { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//CAMELCASE 
        public string Id_Account { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionHour { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal OldBalance { get; set; }
        public decimal FinalBalance { get; set; }
        public string TransactionProcess { get; set; }
        public bool TransactionState { get; set; }

    }
}