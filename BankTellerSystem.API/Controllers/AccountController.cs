using BankTellerSystem.API.Controllers.BaseControllers;
using BankTellerSystem.Application.Accounts.Commands.CreateAccount;
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
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return Created();
    }
}
