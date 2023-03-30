using MongoDB.Bson.Serialization.Attributes;

namespace LeaderBank.Mongo.Infrastructure.Entities.Wrappers.AdvisorComplete
{
    public class AdvisorCompleteEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//CAMELCASE 
        public string Advisor_Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public List<CustomerComplete.CustomerCompleteEntity> Customers { get; set; } = new();
    }
}
