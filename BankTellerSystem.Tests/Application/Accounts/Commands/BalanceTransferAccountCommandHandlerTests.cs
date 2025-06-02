using BankTellerSystem.Application.Accounts.Commands.BalanceTransferAccount;
using BankTellerSystem.Application.Accounts.Commands.CreateAccount;
using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Enums;
using BankTellerSystem.Domain.Exceptions;
using BankTellerSystem.Domain.Interfaces.Infra;
using FluentAssertions;
using Moq;
using Xunit;

namespace BankTellerSystem.Tests.Application.Accounts.Commands;

[Trait("UnitTest", nameof(BalanceTransferAccountCommandHandler))]
public class BalanceTransferAccountCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly BalanceTransferAccountCommandHandler _handler;

    public BalanceTransferAccountCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new BalanceTransferAccountCommandHandler(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Throw_When_Any_Account_Is_Null()
    {
        // Arrange
        var command = new BalanceTransferAccountCommand(Guid.NewGuid(), Guid.NewGuid(), 10);

        _unitOfWorkMock.Setup(u => u.Accounts.GetByIdAsync(command.sourceAccountGuid)).ReturnsAsync((Account)null!);
        _unitOfWorkMock.Setup(u => u.Accounts.GetByIdAsync(command.destinationAccountGuid)).ReturnsAsync((Account)null!);

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should()
            .ThrowAsync<BusinessException>()
            .WithMessage("Accounts not valid.");
    }

    [Fact]
    public async Task Handle_Should_Throw_When_Any_Account_Is_Inactive()
    {
        // Arrange
        var sourceAccount = Account.Create(Guid.NewGuid());
        var destinationAccount = Account.Create(Guid.NewGuid());

        // Simula conta inativa
        destinationAccount.Deactive("12345678900");

        sourceAccount.AddAmount(100);

        var command = new BalanceTransferAccountCommand(
            sourceAccount.Guid,
            destinationAccount.Guid,
            10
        );

        _unitOfWorkMock.Setup(u => u.Accounts.GetByIdAsync(command.sourceAccountGuid)).ReturnsAsync(sourceAccount);
        _unitOfWorkMock.Setup(u => u.Accounts.GetByIdAsync(command.destinationAccountGuid)).ReturnsAsync(destinationAccount);

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should()
            .ThrowAsync<BusinessException>()
            .WithMessage("All the accounts have to be active.");
    }
}
