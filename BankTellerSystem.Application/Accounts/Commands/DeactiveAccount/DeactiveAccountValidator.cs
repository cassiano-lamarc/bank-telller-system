using FluentValidation;

namespace BankTellerSystem.Application.Accounts.Commands.DeactiveAccount;

public class DeactiveAccountValidator: AbstractValidator<DeactiveAccountCommand>
{
    public DeactiveAccountValidator()
    {
        RuleFor(x => x.clientDoc)
            .NotEmpty()
            .WithMessage("Client document can not be empty");
        RuleFor(x => x.loggedUserDoc)
            .NotEmpty()
            .WithMessage("Logged user document can not be empty");
    }
}
