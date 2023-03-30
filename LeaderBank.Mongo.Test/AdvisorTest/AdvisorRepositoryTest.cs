using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisor;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using Moq;

namespace LeaderBank.Mongo.Test.AdvisorTest
{
    public class AdvisorRepositoryTest
    {
        private readonly Mock<IAdvisorRepository> _mockadvisorRepository;
        public AdvisorRepositoryTest()
        {
            _mockadvisorRepository = new();
        }

        [Fact]
        public async Task AddAdvisor()
        {
            // Arrange
            var advisor = new Advisor
            {
                Names = "rola",
                SurNames = "Test",
                Address = "Test",
                Email = "rola@mail.com",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Gender = "F"

            };
            var advisorEntity = new AdvisorEntity
            {
                Advisor_Id = Guid.NewGuid().ToString(),
                Names = "rola",
                Surnames = "Test",
                Address = "Test",
                Email = "rola@mail,com",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Gender = "F"

            };
            _mockadvisorRepository.Setup(x => x.AddAdvisor(advisor)).ReturnsAsync(advisor);
            // Act
            var result = await _mockadvisorRepository.Object.AddAdvisor(advisor);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(advisorEntity.Names, result.Names);

        }

        [Fact]
        public async Task GetListAdvisors()
        {
            // Arrange
            var advisor = new Advisor
            {
                Names = "rola",
                SurNames = "Test",
                Address = "Test",
                Email = "rola@mail.com",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Gender = "F"
            };

            var advisorList = new List<Advisor> { advisor };
            _mockadvisorRepository.Setup(x => x.GetListAdvisors()).ReturnsAsync(advisorList);

            //Act
            var result = await _mockadvisorRepository.Object.GetListAdvisors();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(advisorList, result);
        }

        [Fact]
        public async Task GetAdvisorCompleteByIdAsync()
        {
            // Arrange
            var advisorComplete = new AdvisorComplete
            {
                Advisor_Id = "123456789",
                Names = "Kevin",
                SurNames = "Baquero",
                Address = "Test",
                Email = "kb@gmail.com",
                Phone = "3005558899",
                Birthdate = DateTime.Now,
                Gender = "Male",
                Customers = new List<CustomerComplete>
                {
                    new CustomerComplete
                    {
                        Customer_Id = "987654321",
                        Id_Advisor = "123456789",
                        Names = "Estevan",
                        Surnames = "Tangarife",
                        Address = "Test",
                        Email = "",
                        Phone = "123456789",
                        Birthdate = DateTime.Now,
                        Occupation = "Developer",
                        Gender = "Male",
                        State = true,
                        Accounts = new List<AccountComplete>
                        {
                            new AccountComplete
                            {
                                Account_Id = "9999999",
                                Id_Customer = "987654321",
                                Id_Card = "555555",
                                Id_Advisor = "123456789",
                                AccountType = "Ahorros",
                                Balance = 1000,
                                ManagementCost = 1000,
                                Card = new Card
                                {
                                    Card_Id = Guid.NewGuid().ToString(),
                                    Id_Advisor = "123456789",
                                    NumberCard = "777777777",
                                    Cvc = "123",
                                    EmissionDate = DateTime.Now,
                                    ExpirationDate = DateTime.Now,
                                    CardState = true
                                },
                                Transactions = new List<Transaction>
                                {
                                    new Transaction
                                    {
                                        Id_Account = "9999999",
                                        TransactionType = "Deposito",
                                        Description = "Deposito de 1000",
                                        Amount = 1000
                                    }
                                }
                            }
                        }
                    }
                }
            };

            _mockadvisorRepository.Setup(a => a.GetAdvisorCompleteByIdAsync("123456789")).ReturnsAsync(advisorComplete);

            // Act
            var result = await _mockadvisorRepository.Object.GetAdvisorCompleteByIdAsync("123456789");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(advisorComplete, result);
        }
    }
}
