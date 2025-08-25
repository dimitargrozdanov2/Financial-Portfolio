using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Web.Extensions;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolioSystem.Web.Façade;

public interface IAppMediator
{
    Task<ActionResult> QueryAsync(IQuery<Result> request);
    Task<ActionResult<TResult>> QueryAsync<TResult>(IQuery<TResult> request);
    Task<ActionResult> SendCommandAsync(ICommand<Result> request);
    Task<ActionResult<TResult>> SendCommandAsync<TResult>(ICommand<Result<TResult>> request);
    Task<ActionResult<TResult>> SendCommandAsync<TResult>(ICommand<TResult> request);
}

public class AppMediator(ICommandMediator commandMediator, IQueryMediator queryMediator) : IAppMediator
{
    private readonly ICommandMediator _commandMediator = commandMediator;
    private readonly IQueryMediator _queryMediator = queryMediator;

    public async Task<ActionResult<TResult>> QueryAsync<TResult>(IQuery<TResult> request)
        => await _queryMediator.QueryAsync(request).ToActionResult();

    public Task<ActionResult> QueryAsync(IQuery<Result> request)
        => _queryMediator.QueryAsync(request).ToActionResult();

    public async Task<ActionResult<TResult>> SendCommandAsync<TResult>(ICommand<TResult> request)
        => await _commandMediator.SendAsync(request).ToActionResult();

    public Task<ActionResult> SendCommandAsync(ICommand<Result> request)
        => _commandMediator.SendAsync(request).ToActionResult();

    public async Task<ActionResult<TResult>> SendCommandAsync<TResult>(ICommand<Result<TResult>> request)
        => await _commandMediator.SendAsync(request).ToActionResult();
}
