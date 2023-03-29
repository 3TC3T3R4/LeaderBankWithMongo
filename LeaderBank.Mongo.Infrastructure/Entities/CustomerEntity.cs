using MongoDB.Bson.Serialization.Attributes;

namespace LeaderBank.Mongo.Infrastructure.Entities
{
    public class CustomerEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//CAMELCASE 
        public string Customer_Id { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id_Advisor { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public bool State { get; set; }
    }
}
