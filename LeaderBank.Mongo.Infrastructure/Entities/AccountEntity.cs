using MongoDB.Bson.Serialization.Attributes;

namespace LeaderBank.Mongo.Infrastructure.Entities
{
    public class AccountEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Account_Id { get; set; }

        public string Id_Customer { get; set; }
        public string Id_Card { get; set; }
        public string Id_Advisor { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public decimal ManagementCost { get; set; }
        public bool AccountState { get; set; }
    }
}