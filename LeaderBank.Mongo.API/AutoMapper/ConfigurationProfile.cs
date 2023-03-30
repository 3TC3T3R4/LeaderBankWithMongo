using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Advisor;
using LeaderBank.Mongo.Domain.Entities.Wrappers.Customer;
using LeaderBank.Mongo.Infrastructure.Entities;
using LeaderBank.Mongo.Infrastructure.Entities.Wrappers.AdvisorComplete;
using LeaderBank.Mongo.Infrastructure.Entities.Wrappers.CustomerComplete;

namespace LeaderBank.Mongo.API.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<NewTransaction, Transaction>().ReverseMap();
            CreateMap<TransactionEntity, Transaction>().ReverseMap();

            CreateMap<NewAdvisor, Advisor>().ReverseMap();
            CreateMap<AdvisorEntity, Advisor>().ReverseMap();
            CreateMap<AdvisorEntity, AdvisorComplete>().ReverseMap();
            CreateMap<AdvisorCompleteEntity, AdvisorComplete>().ReverseMap();

            CreateMap<NewCard, Card>().ReverseMap();
            CreateMap<CardEntity, Card>().ReverseMap();

            CreateMap<NewAccount, Account>().ReverseMap();
            CreateMap<AccountEntity, Account>().ReverseMap();
            CreateMap<AccountEntity, AccountComplete>().ReverseMap();
            CreateMap<AccountCompleteEntity, AccountComplete>().ReverseMap();

            CreateMap<InsertNewCustomer, Customer>().ReverseMap();
            CreateMap<CustomerEntity, Customer>().ReverseMap();
            CreateMap<CustomerEntity, CustomerComplete>().ReverseMap();
            CreateMap<CustomerCompleteEntity, CustomerComplete>().ReverseMap();
        }
    }
}
