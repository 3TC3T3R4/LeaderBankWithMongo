using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.Commands
{
    public class InsertNewCustomer
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

        public bool State = true;

    }
}
