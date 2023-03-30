using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;

namespace LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountsAsync();
        Task<NewAccount> CreateAccountAsync(Account account);
    }
}
