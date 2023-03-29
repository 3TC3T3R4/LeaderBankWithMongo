using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.Commands
{
    public class NewCard
    {
        public string Id_Advisor { get; set; }
        public string NumberCard { get; set; }
        public string Cvc { get; set; }        
    }
}
