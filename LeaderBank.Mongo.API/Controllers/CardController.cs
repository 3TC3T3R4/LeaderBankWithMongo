using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBank.Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly ICardUseCase _cardUseCase;
        private readonly IMapper _mapper;

        public CardController(ICardUseCase cardUseCase, IMapper mapper)
        {
            _cardUseCase = cardUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Card>> Get_List_Card()
        {
            return await _cardUseCase.GetListCards();
        }

        [HttpPost]
        public async Task<Card> Create_Card([FromBody] NewCard command)
        {
            return await _cardUseCase.AddCard(_mapper.Map<Card>(command));
        }

    }
}
