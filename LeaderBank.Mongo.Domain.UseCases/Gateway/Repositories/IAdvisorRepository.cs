using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface IAdvisorRepository
    {
        Task<Advisor> AddAdvisor(Advisor advisor);
        Task<List<Advisor>> GetListAdvisors();
        Task<List<CustomerComplete>> GetListAdvisorWithCustomers(string idAdvisor);

    }
}
