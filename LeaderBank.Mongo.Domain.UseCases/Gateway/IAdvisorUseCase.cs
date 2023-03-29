using LeaderBank.Mongo.Domain.Entities;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway
{
    public interface IAdvisorUseCase
    {
        Task<Advisor> AddAdvisor(Advisor advisor);
        Task<List<Advisor>> GetListAdvisors();


    }
}
