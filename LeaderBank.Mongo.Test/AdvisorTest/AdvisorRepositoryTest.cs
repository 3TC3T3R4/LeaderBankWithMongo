using Castle.Core.Resource;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
    }
}
