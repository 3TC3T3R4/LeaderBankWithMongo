using LeaderBank.Mongo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.UseCases
{
   public interface  ICustomerUseCase
    {
        Task<Customer> AddCustomer(Customer customer);

        Task<List<Customer>> GetListCustomers();




    }
}
