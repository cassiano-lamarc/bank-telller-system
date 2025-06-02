using AutoMapper;
using BankTellerSystem.Application.DTO;
using BankTellerSystem.Domain.Entities;

namespace BankTellerSystem.Application.Configurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Account, RegisteredAccounts>()
            .ForMember(a => a.ClientName, opt => opt.MapFrom(src => src.Client.Name))
            .ForMember(a => a.ClientDocument, opt => opt.MapFrom(src => src.Client.Doc))
            .ForMember(a => a.AccountGuid, opt => opt.MapFrom(src => src.Guid))
            .ForMember(a => a.AccountStatus, opt => opt.MapFrom(src => src.Status));
    }
}
