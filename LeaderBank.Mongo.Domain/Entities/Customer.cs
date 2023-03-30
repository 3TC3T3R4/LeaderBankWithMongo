using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.Entities
{
    public class Customer
    {
        public string Customer_Id { get; set; }
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

        public Customer() { }

        //validate customer

        public static void Validate(Customer customer)
        {
            if (customer.Id_Advisor == null)
            {
                throw new ArgumentNullException("The customer id type is required.");
            }
            if (customer.Names == null)
            {
                throw new ArgumentNullException("The name type is required.");
            }
            if (customer.Surnames == null)
            {
                throw new ArgumentNullException("The surname type is required.");
            }
            if (customer.Address == null)
            {
                throw new ArgumentNullException("The address type is required.");
            }
            if (customer.Email == null)
            {
                throw new ArgumentNullException("The email type is required.");
            }
            if (customer.Phone == null)
            {
                throw new ArgumentNullException("The name phone is required.");
            }
            if (customer.Birthdate == null)
            {
                throw new ArgumentNullException("The birthdate type is required.");
            }
            if (customer.Occupation == null)
            {
                throw new ArgumentNullException("The occupation type is required.");
            }
            if (customer.Gender == null)
            {
                throw new ArgumentNullException("The gender type is required.");
            }
            if (customer.State == null)
            {
                throw new ArgumentNullException("The state type is required.");
            }

        }

    }


}
