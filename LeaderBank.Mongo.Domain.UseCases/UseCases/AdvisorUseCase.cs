﻿using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;

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