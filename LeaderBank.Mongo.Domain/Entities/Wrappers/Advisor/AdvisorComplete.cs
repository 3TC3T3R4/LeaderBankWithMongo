using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;

namespace LeaderBank.Mongo.Domain.Entities.Wrappers.Advisor
{
    public class AdvisorComplete // with customers
    {
        public string Advisor_Id { get; set; }
        public string Names { get; set; }
        public string SurNames { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public List<CustomerComplete> Customers { get; set; }
    }
}
