namespace LeaderBank.Mongo.Domain.Commands
{
    public class NewCard
    {
        public string Id_Advisor { get; set; }
        public string NumberCard { get; set; }
        public string Cvc { get; set; }
    }
}
