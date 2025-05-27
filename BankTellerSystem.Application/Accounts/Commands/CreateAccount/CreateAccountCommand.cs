using MediatR;

namespace BankTellerSystem.Application.Accounts.Commands.CreateAccount;

public record CreateAccountCommand(string clientName, string clientDoc) : IRequest<Guid>;