using FluentValidation;

namespace BankTellerSystem.Application.Accounts.Commands.BalanceTransferAccount;

public class BalanceTransferAccountValidator : AbstractValidator<BalanceTransferAccountCommand>
{
    public BalanceTransferAccountValidator()
    {
        RuleFor(b => b.amount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Amount must be greater than zero");

        RuleFor(b => b.sourceAccountGuid)
            .NotEmpty()
            .WithMessage("Source account GUID cannot be empty");

        RuleFor(b => b.destinationAccountGuid)
            .NotEmpty()
            .WithMessage("Destination Account GUID cannot be empty");
    }
}
