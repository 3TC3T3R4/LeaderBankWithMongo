using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.UseCases.UseCases
{
    public class AdvisorUseCase : IAdvisorUseCase
    {
        private readonly IAdvisorRepository _advisorRepository;

        public AdvisorUseCase(IAdvisorRepository advisorRepository)
        {
            _advisorRepository = advisorRepository;
        }

        public async Task<Advisor> AddAdvisor(Advisor advisor)
        {
            return await _advisorRepository.AddAdvisor(advisor);
        }

        public async Task<List<Advisor>> GetListAdvisors()
        {
            return await _advisorRepository.GetListAdvisors();
        }

    }
}
