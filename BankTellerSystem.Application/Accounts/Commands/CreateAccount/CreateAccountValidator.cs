using FluentValidation;

namespace BankTellerSystem.Application.Accounts.Commands.CreateAccount;

public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountValidator()
    {
        RuleFor(x => x.clientName)
            .NotEmpty()
            .WithMessage("Client name can not be empty");

        RuleFor(x => x.clientDoc)
            .NotEmpty()
            .WithMessage("Client document can not be empty");
    }
}
