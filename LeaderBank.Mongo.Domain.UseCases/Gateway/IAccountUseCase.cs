using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway
{
    public interface IAccountUseCase
    {
        Task<List<Account>> GetAccountsAsync();
        Task<NewAccount> CreateAccountAsync(Account account);
    }
}
