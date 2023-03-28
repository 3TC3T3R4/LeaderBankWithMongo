using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<Customer>> GetListCustomers()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }





    }
}
