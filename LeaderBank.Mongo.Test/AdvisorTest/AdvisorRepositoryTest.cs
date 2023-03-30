using Castle.Core.Resource;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisors;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBank.Mongo.Test.AdvisorTest
{
    public class AdvisorRepositoryTest
    {
        private readonly Mock<IAdvisorRepository> _mockadvisorRepository;
        public AdvisorRepositoryTest()
        {
            _mockadvisorRepository = new();
        }

        [Fact]
        public async Task AddAdvisor()
        {
            // Arrange
            var advisor = new Advisor
            {
                Names = "rola",
                SurNames = "Test",
                Address = "Test",
                Email = "rola@mail.com",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Gender = "F"

            };
            var advisorEntity = new AdvisorEntity
            {
                Advisor_Id = Guid.NewGuid().ToString(),
                Names = "rola",
                Surnames = "Test",
                Address = "Test",
                Email = "rola@mail,com",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Gender = "F"

            };
            _mockadvisorRepository.Setup(x => x.AddAdvisor(advisor)).ReturnsAsync(advisor);
            // Act
            var result = await _mockadvisorRepository.Object.AddAdvisor(advisor);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(advisorEntity.Names, result.Names);

        }

        [Fact]
        public async Task GetListAdvisors()
        {
            // Arrange
            var advisor = new Advisor
            {
                Names = "rola",
                SurNames = "Test",
                Address = "Test",
                Email = "rola@mail.com",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Gender = "F"
            };

            var advisorList = new List<Advisor> { advisor };
            _mockadvisorRepository.Setup(x => x.GetListAdvisors()).ReturnsAsync(advisorList);

            //Act
            var result = await _mockadvisorRepository.Object.GetListAdvisors();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(advisorList, result);
        }

        [Fact]
        public async Task GetAdvisorById()
        {
            // Arrange
            var advisor = new Advisor
            {
                Names = "rola",
                SurNames = "Test",
                Address = "Test",
                Email = "" +
                ""
            };
        }

        [Fact]
        public async Task Get_List_Advisor_With_Customers()
        {
            //arrange
            var advisor = new Advisor
            {
                Names = "Juan",
                SurNames = "Perez",
                Address = "Calle 1",
                Email = "",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Gender = "M"
            };
            var customer = new Customer
            {
                Customer_Id = "12345",
                Id_Advisor = "12345",
                Names = "rola",
                Surnames = "Test",
                Address = "Test",
                Email = "",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Occupation = "asesor",
                Gender = "F",
                State = true

            };
            var customerWithAdvisor = new AdvisorWithCustomers
            {
                Advisor_Id = "12345",
                Names = "Juan",
                SurNames = "Perez",
                Address = "Calle 1",
                Email = "",
                Phone = "123456789",
                Birthdate = DateTime.Now,
                Gender = "M",
                Customers = new List<Customer> { customer }

            };

            var listAdvisorWithCustomer = new List<AdvisorWithCustomers> { customerWithAdvisor };
            _mockadvisorRepository.Setup(x => x.GetListAdvisorWithCustomers("1")).ReturnsAsync(listAdvisorWithCustomer);

            //Act
            var result = await _mockadvisorRepository.Object.GetListAdvisorWithCustomers("1");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(listAdvisorWithCustomer, result);

        }
    }

}
