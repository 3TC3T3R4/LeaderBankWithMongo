using LeaderBank.Mongo.Domain.Entities;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface IAdvisorRepository
    {
        Task<Advisor> AddAdvisor(Advisor advisor);
        Task<List<Advisor>> GetListAdvisors();

    }
}
