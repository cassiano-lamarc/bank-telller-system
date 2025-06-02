using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankTellerSystem.Application.DTO;
using BankTellerSystem.Domain.Interfaces.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankTellerSystem.Application.Accounts.Queries;

public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<RegisteredAccounts>>
{
    public GetAccountsQueryHandler(IMapper mapper, IAccountRepository accountRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
    }

    private readonly IMapper _mapper;
    private readonly IAccountRepository _accountRepository;

    public async Task<List<RegisteredAccounts>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        => await _accountRepository.FilterAccount(request.clientName, request.clientDoc)
            .ProjectTo<RegisteredAccounts>(_mapper.ConfigurationProvider).ToListAsync();
}
