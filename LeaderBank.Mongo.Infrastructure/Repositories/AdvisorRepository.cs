using AutoMapper;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisor;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisors;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Entities.Wrappers.CustomerComplete;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace LeaderBank.Mongo.Infrastructure.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly IMongoCollection<AdvisorEntity> advisorCollection;
        private readonly IMongoCollection<CustomerEntity> customerCollection;
        private readonly IMongoCollection<AccountEntity> accountCollection;
        private readonly IMongoCollection<CardEntity> cardCollection;
        private readonly IMongoCollection<TransactionEntity> transactionCollection;
        private readonly IMapper _mapper;

        public AdvisorRepository(IContext context, IMapper mapper)
        {
            advisorCollection = context.Advisors;
            customerCollection = context.Customers;
            accountCollection = context.Accounts;
            cardCollection = context.Cards;
            transactionCollection = context.Transactions;
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

            var createAdvisor = new Advisor
            {
                Names = advisor.Names,
                SurNames = advisor.SurNames,
                Address = advisor.Address,
                Email = advisor.Email,
                Phone = advisor.Phone,
                Birthdate = advisor.Birthdate,                
                Gender = advisor.Gender               

            };
            Advisor.Validate(createAdvisor);
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

            var advisors = await advisorCollection.Find(_ => true).ToListAsync() 
                ?? throw new Exception($"There isn't an advisor with this ID: {idAdvisor}.");

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
            var advisor = await advisorCollection.Find(_ => true).ToListAsync() 
                ?? throw new Exception($"There isn't an advisor with this ID: {idAdvisor}.");

            var advisorWithCards = new List<AdvisorWithCards>();

            foreach (var advisorp in advisor)
            {
                var card = await cardCollection.Find(c => c.Id_Advisor == idAdvisor).ToListAsync();

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

        public async Task<AdvisorComplete> GetAdvisorCompleteByIdAsync(string id)
        {
            var advisor = await advisorCollection.Find(ad => ad.Advisor_Id == id).FirstOrDefaultAsync() 
                ?? throw new Exception($"There isn't an advisor with this ID: {id}.");

            var advisorComplete = _mapper.Map<AdvisorComplete>(advisor);

            var customers = await customerCollection.Find(c => c.Id_Advisor == id).ToListAsync();

            var customersComplete = _mapper.Map<List<CustomerComplete>>(customers);

            foreach (var customer in customersComplete)
            {
                var accounts = accountCollection.Aggregate()
                    .Match(a => a.Id_Advisor == id && a.Id_Customer == customer.Customer_Id)
                    .Lookup<AccountEntity, TransactionEntity, AccountCompleteEntity>(transactionCollection, a => a.Account_Id,
                            t => t.Id_Account, (AccountCompleteEntity ac) => ac.Transactions)
                    .ToList();
                foreach (var account in accounts)
                {
                    foreach (var transaction in account.Transactions)
                    {
                        _mapper.Map<Transaction>(transaction);
                    }
                    _mapper.Map<AccountComplete>(account);

                    var card = await cardCollection.Find(c => c.Card_Id == account.Id_Card).FirstOrDefaultAsync()
                        ?? throw new Exception($"There isn't a card with this ID: {account.Id_Card}.");

                    _mapper.Map<Card>(card);
                    account.Card = card;
                }
                customer.Accounts = _mapper.Map<List<AccountComplete>>(accounts);
            }
            advisorComplete.Customers = customersComplete;
            return advisorComplete;
        }
    }
}
