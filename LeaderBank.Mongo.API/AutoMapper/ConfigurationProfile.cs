using AutoMapper;
using LeaderBank.Mongo.Domain.Commands;
using LeaderBank.Mongo.Domain.Entities;
using LeaderBank.Mongo.Infrastructure.Entities;

namespace LeaderBank.Mongo.API.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<NewTransaction, Transaction>().ReverseMap();
            CreateMap<TransactionEntity, Transaction>().ReverseMap();


        }
    }
}
