using LeaderBank.Mongo.Domain.Entities;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface ICardRepository
    {
        Task<Card> AddCard(Card card);
        Task<List<Card>> GetListCards();
    }
}
