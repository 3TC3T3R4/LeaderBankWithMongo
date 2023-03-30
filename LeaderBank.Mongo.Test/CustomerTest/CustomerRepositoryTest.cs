using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Test.CustomerTest
{
    public class CustomerRepositoryTest
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        public CustomerRepositoryTest()
        {
            _mockCustomerRepository = new();
        }

        [Fact]
        public async Task AddCustomer()
        {
            // Arrange
            var customer = new Customer
            {
                Id_Advisor = "12312341234",
                Names = "rola",
                Surnames = "Test",
                Address = "Test",
                Email = "", 
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Occupation = "asesor",
                Gender = "F",
                State = true


            };
            var customerEntity = new CustomerEntity
            {
                Customer_Id = Guid.NewGuid().ToString(),
                Id_Advisor = "12312341234",
                Names = "rola",
                Surnames = "Test",
                Address = "Test",
                Email = "",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Occupation = "asesor",
                Gender = "F",
                State = true

            };
            _mockCustomerRepository.Setup(x => x.InsertCustomerAsync(customer)).ReturnsAsync(customer);
            // Act
            var result = await _mockCustomerRepository.Object.InsertCustomerAsync(customer);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerEntity.Names, result.Names);

        }

        [Fact]

        public async Task GetListCustomers()
        {
            // Arrange
            var customer = new Customer
            {
                Names = "rola",
                Surnames = "Test",
                Address = "Test",
                Email = "",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Occupation = "asesor",
                Gender = "F",
                State = true
            };

            var customerList = new List<Customer> { customer };
            _mockCustomerRepository.Setup(x => x.GetAllCustomersAsync()).ReturnsAsync(customerList);

            //Act
            var result = await _mockCustomerRepository.Object.GetAllCustomersAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(customerList, result);
        }


        //crear test para GetCustomerCompleteByIdAsync
        [Fact]
        public async Task GetCustomerCompleteByIdAsync()
        {
            //Arrange

            var customer = new Customer
            {
                Names = "rola",
                Surnames = "Test",
                Address = "Test",
                Email = "",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Occupation = "asesor",
                Gender = "F",
                State = true
            };

            var customerList = new List<Customer> { customer};






        }      
       
    }
}
