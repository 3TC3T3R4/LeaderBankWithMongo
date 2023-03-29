using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.Entities
{
    public class Card
    {
        public string Card_Id { get; set; }
        public string Id_Advisor { get; set; }
        public string NumberCard { get; set; }
        public string Cvc { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Boolean CardState { get; set; }

    }
}
