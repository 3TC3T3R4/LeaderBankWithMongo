using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisor;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = LeaderBank.Mongo.Domain.Entities.Transaction;

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

            var customerComplete = new CustomerComplete
            {
                Customer_Id = "56789",
                Names = "Kevin",
                Surnames = "Baquero",
                Address = "Test",
                Email = "kb@gmail.com",
                Phone = "3005558899",
                Birthdate = DateTime.Now,
                Gender = "Male",
                Accounts = new List<AccountComplete>
                {
                    new AccountComplete
                    {
                        Account_Id = "987654321",
                        Id_Customer = "56789",
                        Id_Card = "14423456789",
                        Id_Advisor = "454123456789",
                        Balance = 3000,
                        OpenDate = DateTime.Now,
                        CloseDate = null,
                        ManagementCost = 100,
                        AccountState = true,
                        Card = new Card
                        {
                            Card_Id = "14423456789",
                            Id_Advisor = "454123456789",
                            NumberCard = "010101",
                            Cvc = "345",
                            EmissionDate = DateTime.Now,
                            ExpirationDate = DateTime.Now,
                            CardState = true
                        },
                        Transactions = new List<Transaction>
                        {
                            new Transaction
                            {
                                Id_Account = "987654321",
                                TransactionType = "Deposito",
                                Description = "Deposito de 3000",
                                Amount = 3000
                            }
                        }
                    }
                }
            };

            _mockCustomerRepository.Setup(a => a.GetCustomerCompleteByIdAsync("56789")).ReturnsAsync(customerComplete);

            // Act
            var result = await _mockCustomerRepository.Object.GetCustomerCompleteByIdAsync("56789");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerComplete, result);

        }
   }
}
