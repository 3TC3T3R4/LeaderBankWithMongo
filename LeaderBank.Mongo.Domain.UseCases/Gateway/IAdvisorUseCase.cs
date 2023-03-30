using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisor;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisors;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway
{
    public interface IAdvisorUseCase
    {
        Task<Advisor> AddAdvisor(Advisor advisor);
        Task<List<Advisor>> GetListAdvisors();
        Task<List<AdvisorWithCustomers>> GetListAdvisorWithCustomers(string idAdvisor);
        Task<List<AdvisorWithCards>> GetListAdvisorWithCards(string idAdvisor);
        Task<AdvisorComplete> GetAdvisorCompleteByIdAsync(string id);
    }
}
