namespace LeaderBank.Mongo.Domain.Entities
{
    public class Account
    {
        public string Account_Id { get; set; }
        public string Id_Customer { get; set; }
        public string Id_Card { get; set; }
        public string Id_Advisor { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public decimal ManagementCost { get; set; }
        public bool AccountState { get; set; }

        public Account() { }

        //validate account
        public bool Validate()
        {
            if (Id_Customer == null) return false;
            if (Id_Card == null) return false;
            if (Id_Advisor == null) return false;
            if (AccountType == null) return false;
            if (OpenDate == null) return false;
            if (AccountState == false) return false;
            return true;
        }

        public static Account SetDetailsAccount(Account account)
        {
            account.OpenDate = DateTime.Now;
            account.CloseDate = null;
            account.AccountState = true;
            return account;
        }
    }
}
