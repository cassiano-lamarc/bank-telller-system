using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Exceptions;
using BankTellerSystem.Domain.Interfaces.Infra;
using MediatR;

namespace BankTellerSystem.Application.Accounts.Commands.BalanceTransferAccount;

public class BalanceTransferAccountCommandHandler : IRequestHandler<BalanceTransferAccountCommand, bool>
{
    public BalanceTransferAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    public async Task<bool> Handle(BalanceTransferAccountCommand request, CancellationToken cancellationToken)
    {
        var sourceAccount = await _unitOfWork.Accounts.GetByIdAsync(request.sourceAccountGuid);
        var destinationAccount = await _unitOfWork.Accounts.GetByIdAsync(request.destinationAccountGuid);
        
        ValidateAccounts(sourceAccount, destinationAccount, request.amount);

        sourceAccount.RemoveAmount(request.amount);
        destinationAccount.AddAmount(request.amount);

        AccountHistory sourceAccountHistory = AccountHistory.Create(sourceAccount.Guid, sourceAccount.CurrentBalance);
        AccountHistory destinationAccountHistory = AccountHistory.Create(destinationAccount.Guid, destinationAccount.CurrentBalance);

        _unitOfWork.Accounts.Update(sourceAccount);
        _unitOfWork.Accounts.Update(destinationAccount);
        await _unitOfWork.AccountHistories.AddAsync(sourceAccountHistory);
        await _unitOfWork.AccountHistories.AddAsync(destinationAccountHistory);
        await _unitOfWork.CommitAsync();

        return true;
    }

    public void ValidateAccounts(Account sourceAccount, Account destinationAccount, decimal amount)
    {
        if (sourceAccount is null || destinationAccount is null)
            throw new BusinessException("Accounts not valid.");

        if (!sourceAccount.IsActive() || !destinationAccount.IsActive())
            throw new BusinessException("All the accounts have to be active.");

        if (sourceAccount.CurrentBalance < amount)
            throw new BusinessException("The source account has not enough balance to transfer.");
    }
}
