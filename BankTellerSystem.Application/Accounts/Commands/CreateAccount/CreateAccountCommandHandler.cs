using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Exceptions;
using BankTellerSystem.Domain.Interfaces.Infra;
using MediatR;

namespace BankTellerSystem.Application.Accounts.Commands.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        Client client = Client.Create(request.clientName, request.clientDoc);
        Account account = Account.Create(client.Guid);
        AccountHistory accountHistory = AccountHistory.Create(account.Guid, account.CurrentBalance);

        await _unitOfWork.Clients.AddAsync(client);
        await _unitOfWork.Accounts.AddAsync(account);
        await _unitOfWork.AccountHistories.AddAsync(accountHistory);

        var success = await _unitOfWork.CommitAsync();
        if (!success)
            throw new BusinessException("Occured an error while saving changes. Try again!");

        return account.Guid;
    }
}
