using LeaderBank.Mongo.Domain.Entities;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway
{
    public interface ICardUseCase
    {
        Task<Card> AddCard(Card card);
        Task<List<Card>> GetListCards();
    }
}
