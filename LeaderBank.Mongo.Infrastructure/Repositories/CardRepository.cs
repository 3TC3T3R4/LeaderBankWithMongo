using AutoMapper;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IMongoCollection<CardEntity> cardCollection;
        private readonly IMapper _mapper;

        public CardRepository(IContext context, IMapper mapper)
        {
            cardCollection = context.Cards;
            _mapper = mapper;
        }

        public async Task<Card> AddCard(Card card)
        {
            card.EmissionDate = DateTime.Now;
            card.ExpirationDate = null;
            card.CardState = true;
            var addCard = _mapper.Map<CardEntity>(card);
            await cardCollection.InsertOneAsync(addCard);

            if (addCard == null)
            {
                throw new Exception($"please add card information.");
            }
            var cardToCreate = new Card
            {
                Id_Advisor = card.Id_Advisor,
                NumberCard = card.NumberCard,
                Cvc = card.Cvc,
                EmissionDate = DateTime.Now,
                ExpirationDate = null,
                CardState = card.CardState,
            };

            Card.Validate(cardToCreate);
            return card;

        }

        public async Task<List<Card>> GetListCards()
        {
            var cards = await cardCollection.FindAsync(Builders<CardEntity>.Filter.Empty);
            var listCard = cards.ToEnumerable().Select(cards => _mapper.Map<Card>(cards)).ToList();

            if (cards == null)
            {
                throw new Exception($"please add card information.");
            }
            return listCard;
        }
    }

}