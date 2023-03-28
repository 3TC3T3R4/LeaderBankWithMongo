using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;

namespace LeaderBank.Mongo.Domain.UseCases.UseCases
{
    public class CustomerUseCase : ICustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            return await _customerRepository.InsertCustomerAsync(customer);
        }

        public async Task<CustomerComplete> GetCustomerCompleteByIdAsync(string id)
        {
            return await _customerRepository.GetCustomerCompleteByIdAsync(id);
        }

        public async Task<List<Customer>> GetListCustomers()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }
    }
}
