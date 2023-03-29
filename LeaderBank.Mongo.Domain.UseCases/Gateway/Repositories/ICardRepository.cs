using LeaderBank.Mongo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface ICardRepository
    {
        Task<Card> AddCard(Card card);
        Task<List<Card>> GetListCards();
    }
}
