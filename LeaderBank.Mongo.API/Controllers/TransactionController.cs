using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBank.Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionUseCase _transactionUseCase;
        private readonly IMapper _mapper;
        public TransactionController(ITransactionUseCase transactionUseCase, IMapper mapper)
        {
            _transactionUseCase = transactionUseCase;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await _transactionUseCase.GetTransactionsAsync();
        }
        [HttpPost]
        public async Task<NewTransaction> CreateTransactionAsync([FromBody] NewTransaction newTransaction)
        {
            return await _transactionUseCase.CreateTransactionAsync(_mapper.Map<Transaction>(newTransaction));
        }
    }
}
