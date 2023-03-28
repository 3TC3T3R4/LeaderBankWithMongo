using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetTransactionsAsync();
        Task<NewTransaction> CreateTransactionAsync(Transaction transaction);
    }
}
