using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Test.AccountTest
{
    public class AccountRepositoryTest
    {
        private readonly Mock<IAccountRepository> _mockAccountRepository;
        public AccountRepositoryTest()
        {
            _mockAccountRepository = new();
        }

        [Fact]
        public async Task CreateAccountAsync()
        {
            // Arrange
            var account = new Account
            {
                Id_Customer = "123456789",
                Id_Card = "123456789",
                Id_Advisor = "123456789",
                AccountType = "Ahorros",
                Balance = 1000,                
                ManagementCost = 1000
               
            };
            var newAccount = new NewAccount
            {
                Id_Customer = "123456789",
                Id_Card = "123456789",
                Id_Advisor = "123456789",
                AccountType = "Ahorros",
                Balance = 1000,
                ManagementCost = 1000
            };
            _mockAccountRepository.Setup(x => x.CreateAccountAsync(account)).ReturnsAsync(newAccount);
            // Act
            var result = await _mockAccountRepository.Object.CreateAccountAsync(account);
            // Assert           
            Assert.NotNull(result);
            Assert.Equal(account.Id_Customer, result.Id_Customer);
        }
        [Fact]

        public async Task GetAccountsAsync()
        {
            // Arrange
            var account = new Account
            {
                Id_Customer = "123456789",
                Id_Card = "123456789",
                Id_Advisor = "123456789",
                AccountType = "Ahorros",
                Balance = 1000,
                ManagementCost = 1000
            };

            var accountList = new List<Account> { account };
            _mockAccountRepository.Setup(x => x.GetAccountsAsync()).ReturnsAsync(accountList);

            //Act
            var result = await _mockAccountRepository.Object.GetAccountsAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(accountList, result);
        }

    }
}
