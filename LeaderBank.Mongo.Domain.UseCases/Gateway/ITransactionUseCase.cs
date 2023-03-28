using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway
{
    public interface ITransactionUseCase
    {
        Task<List<Transaction>> GetTransactionsAsync();
        Task<NewTransaction> CreateTransactionAsync(Transaction transaction);
    }
}
