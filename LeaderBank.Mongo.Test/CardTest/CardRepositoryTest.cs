using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Test.CardTest
{
    public class CardRepositoryTest
    {
        private readonly Mock<ICardRepository> _mockCardRepository;
        public CardRepositoryTest()
        {
            _mockCardRepository = new();
        }

        [Fact]
        public async Task AddCard()
        {
            // Arrange
            var card = new Card
            {
                Id_Advisor = "rola",
                NumberCard = "123456789",
                Cvc = "123"

            };
            var cardEntity = new CardEntity
            {
                Card_Id = Guid.NewGuid().ToString(),
                Id_Advisor = "rola",
                NumberCard = "123456789",
                Cvc = "123",
                EmissionDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                CardState = true

            };
            _mockCardRepository.Setup(x => x.AddCard(card)).ReturnsAsync(card);
            // Act
            var result = await _mockCardRepository.Object.AddCard(card);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(cardEntity.NumberCard, result.NumberCard);

        }

        [Fact]

        public async Task GetListCards()
        {
            // Arrange
            var card = new Card
            {
                Id_Advisor = "rola",
                NumberCard = "123456789",
                Cvc = "123"        
          
            };
            var cardList = new List<Card> { card };
            _mockCardRepository.Setup(x => x.GetListCards()).ReturnsAsync(cardList);

            //Act
            var result = await _mockCardRepository.Object.GetListCards();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(cardList, result);
        }

    }
}
