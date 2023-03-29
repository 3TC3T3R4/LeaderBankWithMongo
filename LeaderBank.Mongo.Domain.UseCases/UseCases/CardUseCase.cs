using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
