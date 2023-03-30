namespace LeaderBank.Mongo.Domain.Commands
{
    public class NewAccount
    {
        public string Id_Customer { get; set; }
        public string Id_Card { get; set; }
        public string Id_Advisor { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public decimal ManagementCost { get; set; }
    }
}
