using AutoMapper;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IMongoCollection<CustomerEntity> coleccion;
        private readonly IMapper _mapper;
        public CustomerRepository(IContext context, IMapper mapper)
        {
            this.coleccion = context.Customers;
            _mapper = mapper;
        }
        public async Task<List<Customer>> GetAllCustomersAsync()
        {

            var filter = Builders<CustomerEntity>.Filter.Eq(c => c.State, true);

            var customer = await coleccion.FindAsync(filter);

            var listCustomer = customer.ToEnumerable().Select(client => _mapper.Map<Customer>(client)).ToList();

            return listCustomer;
        }

        public Task<CustomerComplete> GetCustomerCompleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            var customerSave = _mapper.Map<CustomerEntity>(customer);
            await coleccion.InsertOneAsync(customerSave);
            return customer;
        }
    }
}