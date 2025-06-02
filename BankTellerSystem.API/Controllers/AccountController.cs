using BankTellerSystem.API.Controllers.BaseControllers;
using BankTellerSystem.Application.Accounts.Commands.BalanceTransferAccount;
using BankTellerSystem.Application.Accounts.Commands.CreateAccount;
using BankTellerSystem.Application.Accounts.Commands.DeactiveAccount;
using BankTellerSystem.Application.Accounts.Queries;
using BankTellerSystem.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankTellerSystem.API.Controllers;

public class AccountController : BaseController
{
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(BusinessException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return Created();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(BusinessException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] GetAccountsQuery getAccountsQuery) => Ok(await _mediator.Send(getAccountsQuery));

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeactiveAccountCommand request, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(request, cancellationToken));

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(BusinessException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Transfer([FromBody] BalanceTransferAccountCommand request, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(request, cancellationToken));
}
