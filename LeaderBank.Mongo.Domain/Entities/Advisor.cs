using System.Net;
using System.Numerics;
using System.Reflection;

namespace LeaderBank.Mongo.Domain.Entities
{
    public class Advisor
    {
        public string Advisor_Id { get; set; }
        public string Names { get; set; }
        public string SurNames { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }


        public Advisor() { }

        //validate advisor

        public static void Validate(Advisor advisor)
        {
            if (advisor.Names == null)
            {
                throw new ArgumentNullException("The name type is required.");
            }
            if (advisor.SurNames == null)
            {
                throw new ArgumentNullException("The surname type is required.");
            }
            if (advisor.Address == null)
            {
                throw new ArgumentNullException("The address type is required.");
            }
            if (advisor.Email == null)
            {
                throw new ArgumentNullException("The email type is required.");
            }
            if (advisor.Phone == null)
            {
                throw new ArgumentNullException("The name phone is required.");
            }
            if (advisor.Birthdate == null)
            {
                throw new ArgumentNullException("The birthdate type is required.");
            }
            if (advisor.Gender == null)
            {
                throw new ArgumentNullException("The gender type is required.");
            }           

        }


    }

}
