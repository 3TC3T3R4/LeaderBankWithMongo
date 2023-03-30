using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;

namespace LeaderBank.Mongo.Domain.UseCases.UseCases
{
    public class AccountUseCase : IAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<NewAccount> CreateAccountAsync(Account account)
        {
            return await _accountRepository.CreateAccountAsync(account);
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _accountRepository.GetAccountsAsync();
        }
    }
}
