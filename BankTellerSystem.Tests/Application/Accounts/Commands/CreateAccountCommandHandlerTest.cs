using BankTellerSystem.Application.Accounts.Commands.CreateAccount;
using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Exceptions;
using BankTellerSystem.Domain.Interfaces.Infra;
using FluentAssertions;
using Moq;
using Xunit;

namespace BankTellerSystem.Tests.Application.Accounts.Commands;


[Trait("UnitTest", nameof(CreateAccountCommandHandler))]
public class CreateAccountCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly CreateAccountCommandHandler _handler;

    public CreateAccountCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new CreateAccountCommandHandler(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Throw_BusinessException_When_Document_Already_Exists()
    {
        // Arrange
        var command = new CreateAccountCommand("Maria Souza", "11111111111");

        _unitOfWorkMock.Setup(u => u.Accounts.FilterByDoc(command.clientDoc))
            .ReturnsAsync(Account.Create(Guid.NewGuid()));

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should()
            .ThrowAsync<BusinessException>()
            .WithMessage("Already exist an account for this client");

        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Never);
    }

    [Fact]
    public async Task Handle_Should_Throw_BusinessException_When_Commit_Fails()
    {
        // Arrange
        var command = new CreateAccountCommand("Lucas Lima", "98765432100");

        _unitOfWorkMock.Setup(u => u.Accounts.FilterByDoc(command.clientDoc))
            .ReturnsAsync((Account?)null);

        _unitOfWorkMock.Setup(u => u.Clients.AddAsync(It.IsAny<Client>())).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.Accounts.AddAsync(It.IsAny<Account>())).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.AccountHistories.AddAsync(It.IsAny<AccountHistory>())).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.CommitAsync()).ReturnsAsync(false); // Simula erro

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should()
            .ThrowAsync<BusinessException>()
            .WithMessage("Occured an error while saving changes. Try again!");
    }
}
