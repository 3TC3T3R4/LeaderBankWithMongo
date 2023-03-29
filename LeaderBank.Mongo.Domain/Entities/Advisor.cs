using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
