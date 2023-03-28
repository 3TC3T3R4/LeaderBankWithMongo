using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<AccountEntity> accountCollection;
        private readonly IMapper _mapper;

        public AccountRepository(IContext context, IMapper mapper)
        {
            accountCollection = context.Accounts;
            _mapper = mapper;
        }
        public async Task<NewAccount> CreateAccountAsync(Account account)
        {
            Account.SetDetailsAccount(account);
            if (!account.Validate())
            {
                throw new Exception("Any field of account is null or empty.");
            }
            var accountToCreate = _mapper.Map<AccountEntity>(account);
            await accountCollection.InsertOneAsync(accountToCreate);
            return _mapper.Map<NewAccount>(account);
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var accounts = await accountCollection.FindAsync(a => a.AccountState == true);
            var accountsList = _mapper.Map<List<Account>>(accounts.ToList());
            if (accountsList.Count == 0)
            {
                throw new ArgumentException("There aren't accounts to show.");
            }
            return accountsList;
        }
    }
}
