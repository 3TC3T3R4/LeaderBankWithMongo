using LeaderBank.Mongo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway
{
    public interface IAdvisorUseCase
    {
        Task<Advisor> AddAdvisor(Advisor advisor);
        Task<List<Advisor>> GetListAdvisors();
          
              
    }
}
