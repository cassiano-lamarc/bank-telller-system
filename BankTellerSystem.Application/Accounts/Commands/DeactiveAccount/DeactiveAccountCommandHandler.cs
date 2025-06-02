using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Exceptions;
using BankTellerSystem.Domain.Interfaces.Infra;
using MediatR;

namespace BankTellerSystem.Application.Accounts.Commands.DeactiveAccount;

public class DeactiveAccountCommandHandler : IRequestHandler<DeactiveAccountCommand, bool>
{
    public DeactiveAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    public async Task<bool> Handle(DeactiveAccountCommand request, CancellationToken cancellationToken)
    {
        Account? account = await _unitOfWork.Accounts.FilterByDoc(request.clientDoc);
        if (account is null)
            throw new BusinessException("Account not found.");

        account.Deactive(request.loggedUserDoc);
        AccountHistory accountHistory = AccountHistory.Create(account.Guid, account.CurrentBalance);
        await _unitOfWork.AccountHistories.AddAsync(accountHistory);
        _unitOfWork.Accounts.Update(account);

        await _unitOfWork.CommitAsync();

        return true;
    }
}
