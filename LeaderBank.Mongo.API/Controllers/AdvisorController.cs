using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBank.Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {

        private readonly IAdvisorUseCase _advisorUseCase;
        private readonly IMapper _mapper;

        public AdvisorController(IAdvisorUseCase advisorUseCase, IMapper mapper)
        {
            _advisorUseCase = advisorUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Advisor>> Get_List_Advisor()
        {
            return await _advisorUseCase.GetListAdvisors();
        }

        [HttpPost]
        public async Task<Advisor> Create_Advisor([FromBody] NewAdvisor command)
        {
            return await _advisorUseCase.AddAdvisor(_mapper.Map<Advisor>(command));
        }

    }
}
