using MongoDB.Bson.Serialization.Attributes;

namespace LeaderBank.Mongo.Infrastructure.Entities
{
    public class CardEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//CAMELCASE 
        public string Card_Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//CAMELCASE 
        public string Id_Advisor { get; set; }
        public string NumberCard { get; set; }
        public string Cvc { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Boolean CardState { get; set; }

    }
}
