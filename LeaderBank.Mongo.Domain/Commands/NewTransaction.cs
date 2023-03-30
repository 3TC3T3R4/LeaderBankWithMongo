namespace LeaderBank.Mongo.Domain.Commands
{
    public class NewTransaction
    {
        public string Id_Account { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
