using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;

namespace LeaderBank.Mongo.Domain.UseCases.UseCases
{
    public class CardUseCase : ICardUseCase
    {
        private readonly ICardRepository _cardRepository;

        public CardUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> AddCard(Card card)
        {
            return await _cardRepository.AddCard(card);
        }

        public async Task<List<Card>> GetListCards()
        {
            return await _cardRepository.GetListCards();
        }

    }
}
