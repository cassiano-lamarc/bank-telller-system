using BankTellerSystem.Application.DTO;
using MediatR;

namespace BankTellerSystem.Application.Accounts.Queries;

public record GetAccountsQuery(string clientName, string clientDoc) : IRequest<List<RegisteredAccounts>>;
