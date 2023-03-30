using AutoMapper;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisor;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisors;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace LeaderBank.Mongo.Infrastructure.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly IMongoCollection<AdvisorEntity> advisorCollection;
        private readonly IMongoCollection<CustomerEntity> customerCollection;
        private readonly IMongoCollection<CardEntity> cardCollection;

        private readonly IMapper _mapper;
      

        public AdvisorRepository(IContext context, IMapper mapper)
        {
            advisorCollection = context.Advisors;
            customerCollection = context.Customers;
            cardCollection = context.Cards;
            _mapper = mapper;
        }

        public async Task<Advisor> AddAdvisor(Advisor advisor)
        {
            var addAdvisor = _mapper.Map<AdvisorEntity>(advisor);
            await advisorCollection.InsertOneAsync(addAdvisor);

            if (addAdvisor == null)
            {
                throw new Exception($"please add advisor information.");
            }
            return advisor;
        }

        public async Task<List<Advisor>> GetListAdvisors()
        {
            var advisors = await advisorCollection.FindAsync(Builders<AdvisorEntity>.Filter.Empty);
            var listAdvisor = advisors.ToEnumerable().Select(advisors => _mapper.Map<Advisor>(advisors)).ToList();

            if (advisors == null)
            {
                throw new Exception($"please add advisor information.");
            }
            return listAdvisor;
        }

        public async Task<List<AdvisorWithCustomers>> GetListAdvisorWithCustomers(string idAdvisor)
        {          
           
            var advisors = await advisorCollection.Find(_ => true).ToListAsync();

            var advisorWithCustomers = new List<AdvisorWithCustomers>();

            foreach (var advisorf in advisors)

            {
                var customer = await customerCollection.Find(c => c.Id_Advisor == idAdvisor).ToListAsync();

                var advisorWithCustomer = new AdvisorWithCustomers
                {
                    Advisor_Id = advisorf.Advisor_Id,
                    Names = advisorf.Names,
                    SurNames = advisorf.Surnames,
                    Address = advisorf.Address,
                    Email = advisorf.Email,
                    Phone = advisorf.Phone,
                    Birthdate = advisorf.Birthdate,
                    Gender = advisorf.Gender,
                    Customers = _mapper.Map<List<Customer>>(customer)

            };

                advisorWithCustomers.Add(advisorWithCustomer);
            }

            return advisorWithCustomers;
        }

        public async Task<List<AdvisorWithCards>> GetListAdvisorWithCards(string idAdvisor) 
        {
            var advisor = await advisorCollection.Find(_ => true).ToListAsync();

            var advisorWithCards = new List<AdvisorWithCards>();

            foreach (var advisorp in advisor)

            {
                var card = await cardCollection.Find(c => c.Card_Id == idAdvisor).ToListAsync();

                var advisorWithCard = new AdvisorWithCards
                {
                    Advisor_Id = advisorp.Advisor_Id,
                    Names = advisorp.Names,
                    SurNames = advisorp.Surnames,
                    Address = advisorp.Address,
                    Email = advisorp.Email,
                    Phone = advisorp.Phone,
                    Birthdate = advisorp.Birthdate,
                    Gender = advisorp.Gender,
                    Cards = _mapper.Map<List<Card>>(card)

                };

                advisorWithCards.Add(advisorWithCard);
            }

            return advisorWithCards;

        }

    }
}
