using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBank.Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountUseCase _accountUseCase;
        private readonly IMapper _mapper;
        public AccountController(IAccountUseCase accountUseCase, IMapper mapper)
        {
            _accountUseCase = accountUseCase;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _accountUseCase.GetAccountsAsync();
        }
        [HttpPost]
        public async Task<NewAccount> CreateAccountAsync([FromBody] NewAccount newAccount)
        {
            return await _accountUseCase.CreateAccountAsync(_mapper.Map<Account>(newAccount));
        }
    }
}
