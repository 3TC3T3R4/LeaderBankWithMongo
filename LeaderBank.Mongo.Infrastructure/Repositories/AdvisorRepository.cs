using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly IMongoCollection<AdvisorEntity> advisorCollection;
        private readonly IMapper _mapper;

        public AdvisorRepository(IContext context, IMapper mapper)
        {
            advisorCollection = context.Advisors;
            _mapper = mapper;
        }

        public async Task<Advisor> AddAdvisor(Advisor advisor)
        {
            var addAdvisor = _mapper.Map<AdvisorEntity>(advisor);
            await advisorCollection.InsertOneAsync(addAdvisor);

            if (addAdvisor == null)
            {
                throw new Exception($"please add advisor information.");
            }
            return advisor;
        }

        public async Task<List<Advisor>> GetListAdvisors()
        {
            var advisors = await advisorCollection.FindAsync(Builders<AdvisorEntity>.Filter.Empty);
            var listAdvisor = advisors.ToEnumerable().Select(advisors => _mapper.Map<Advisor>(advisors)).ToList();

            if (advisors == null)
            {
                throw new Exception($"please add advisor information.");
            }
            return listAdvisor;
        }

    }

}
