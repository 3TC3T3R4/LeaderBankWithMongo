namespace LeaderBank.Mongo.Domain.Entities
{
    public class Transaction
    {
        public string Transaction_Id { get; set; }
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

        public Transaction() { }

        //validate transaction
        public static void Validate(Transaction transaction)
        {
            if (transaction.Id_Account == null)
            {
                throw new ArgumentNullException("Account ID cannot be null");
            }
            if (transaction.TransactionDate == null)
            {
                throw new ArgumentNullException("Transaction Date cannot be null");
            }
            if (transaction.TransactionHour == null)
            {
                throw new ArgumentNullException("The TransactionHour type is required.");
            }
            if (transaction.TransactionType == null)
            {
                throw new ArgumentNullException("The TransactionType type is required.");
            }
            if (transaction.Description == null)
            {
                throw new ArgumentNullException("The Description phone is required.");
            }
            if (transaction.Amount == null || transaction.Amount == 0)
            {
                throw new ArgumentNullException("The Amount cannot be null or zero");
            }
            if (transaction.OldBalance == null)
            {
                throw new ArgumentNullException("The OldBalance type is required.");
            }
            if (transaction.FinalBalance == null)
            {
                throw new ArgumentNullException("The FinalBalance is required.");
            }
            if (transaction.TransactionProcess == null)
            {
                throw new ArgumentNullException("The TransactionProcess is required.");
            }
            if (transaction.TransactionState == null)
            {
                throw new ArgumentNullException("The TransactionState is required.");
            }
        }

        public static Transaction SetDetailsTransaction(Transaction transaction)
        {
            transaction.TransactionDate = DateOnly.FromDateTime(DateTime.Now).ToString();
            transaction.TransactionHour = TimeOnly.FromDateTime(DateTime.Now).ToString();
            transaction.OldBalance = transaction.Amount;
            transaction.FinalBalance = transaction.Amount;
            transaction.TransactionProcess = "Aprobada";
            transaction.TransactionState = true;
            return transaction;
        }
    }
}
