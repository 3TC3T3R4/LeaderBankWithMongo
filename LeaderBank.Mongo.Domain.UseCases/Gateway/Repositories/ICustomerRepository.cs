using LeaderBank.Mongo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface ICustomerRepository
    {

        Task<Customer> InsertCustomerAsync(Customer customer);

        Task<List<Customer>> GetAllCustomersAsync();


    }
}
