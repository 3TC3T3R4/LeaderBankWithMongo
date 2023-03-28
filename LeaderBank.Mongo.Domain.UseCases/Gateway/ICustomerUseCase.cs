using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway
{
    public interface ICustomerUseCase
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<List<Customer>> GetListCustomers();
        Task<CustomerComplete> GetCustomerCompleteByIdAsync(string id);

    }
}
