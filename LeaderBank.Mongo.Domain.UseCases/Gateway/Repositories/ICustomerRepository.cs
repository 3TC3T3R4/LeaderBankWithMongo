using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> InsertCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<CustomerComplete> GetCustomerCompleteByIdAsync(string id);

    }
}
