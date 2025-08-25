using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Web.Façade;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolioSystem.Web.Common;

[ApiController]
[Route("/api/[controller]")]
public abstract class ApiController : ControllerBase
{
    public const string PathSeparator = "/";
    public const string Id = "{id}";

    private readonly IAppMediator _mediator;

    protected ApiController(IAppMediator mediator)
    {
        _mediator = mediator;
    }


    protected async Task<ActionResult<TResult>> SendAsync<TResult>(IQuery<TResult> request)
        => await _mediator.QueryAsync(request);

    protected async Task<ActionResult> SendAsync(IQuery<Result> request)
        => await _mediator.QueryAsync(request);

    protected async Task<ActionResult<TResult>> SendAsync<TResult>(ICommand<TResult> request)
        => await _mediator.SendCommandAsync(request);

    protected async Task<ActionResult> SendAsync(ICommand<Result> request)
        => await _mediator.SendCommandAsync(request);

    protected async Task<ActionResult<TResult>> SendAsync<TResult>(ICommand<Result<TResult>> request)
        => await _mediator.SendCommandAsync(request);
}
