using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisor;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisors;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface IAdvisorRepository
    {
        Task<Advisor> AddAdvisor(Advisor advisor);
        Task<List<Advisor>> GetListAdvisors();
        Task<List<AdvisorWithCustomers>> GetListAdvisorWithCustomers(string idAdvisor);

        Task<List<AdvisorWithCards>> GetListAdvisorWithCards(string idAdvisor);

    }
}
