using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Test.TransactionTest
{
    public class AccountRepositoryTest
    {
        private readonly Mock<ITransactionRepository> _mockTransactionRepository;
        public AccountRepositoryTest()
        {
            _mockTransactionRepository = new();
        }

        [Fact]
        public async Task CreateTransactionAsync()
        {
            // Arrange
            var transaction = new Transaction
            {
                Id_Account = "123456789",
                TransactionType = "Deposito",
                Description = "Deposito de 1000",
                Amount = 1000              


            };
            var newTransaction = new NewTransaction
            {
                Id_Account = "123456789",
                TransactionType = "Deposito",
                Description = "Deposito de 1000",
                Amount = 1000
            };
            _mockTransactionRepository.Setup(x => x.CreateTransactionAsync(transaction)).ReturnsAsync(newTransaction);
            // Act
            var result = await _mockTransactionRepository.Object.CreateTransactionAsync(transaction);
            // Assert            
            Assert.NotNull(result);
            Assert.Equal(transaction.Id_Account, result.Id_Account);
            
        }
        

    }
}
