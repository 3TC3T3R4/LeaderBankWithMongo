using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBank.Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerUseCase _customerUseCase;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerUseCase customerUseCase, IMapper mapper)
        {
            _customerUseCase = customerUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Customer>> Get_List_Customer()
        {
            return await _customerUseCase.GetListCustomers();
        }

        [HttpPost]
        public async Task<Customer> Create_Customer([FromBody] InsertNewCustomer command)
        {
            return await _customerUseCase.AddCustomer(_mapper.Map<Customer>(command));
        }
    }
}
