using MediatR;

namespace BankTellerSystem.Application.Accounts.Commands.DeactiveAccount;

public record DeactiveAccountCommand(string clientDoc, string loggedUserDoc): IRequest<bool>;
