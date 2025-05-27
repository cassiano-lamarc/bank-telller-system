using BankTellerSystem.Domain.Entities;
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

        await _unitOfWork.BeginTransaction();

        await _unitOfWork.Clients.AddAsync(client);
        await _unitOfWork.Accounts.AddAsync(account);

        var success = await _unitOfWork.CommitAsync();
        if (!success)
            throw new Exception("Occured an error while saving changes. Try again!");

        return account.Guid;
    }
}
