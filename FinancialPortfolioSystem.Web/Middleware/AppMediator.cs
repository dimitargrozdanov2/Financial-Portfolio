using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Web.Extensions;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolioSystem.Web.Middleware
{
    public interface IAppMediator
    {
        Task<ActionResult> QueryAsync(IQuery<Result> request);
        Task<ActionResult<TResult>> QueryAsync<TResult>(IQuery<TResult> request);
        Task<ActionResult> SendCommandAsync(ICommand<Result> request);
        Task<ActionResult<TResult>> SendCommandAsync<TResult>(ICommand<Result<TResult>> request);
        Task<ActionResult<TResult>> SendCommandAsync<TResult>(ICommand<TResult> request);
    }

    public class AppMediator : IAppMediator
    {
        private readonly ICommandMediator _commandMediator;
        private readonly IQueryMediator _queryMediator;

        public AppMediator(ICommandMediator commandMediator, IQueryMediator queryMediator)
        {
            _commandMediator = commandMediator;
            _queryMediator = queryMediator;
        }

        public async Task<ActionResult<TResult>> QueryAsync<TResult>(IQuery<TResult> request)
            => await this._queryMediator.QueryAsync(request).ToActionResult();

        public Task<ActionResult> QueryAsync(IQuery<Result> request)
            => this._queryMediator.QueryAsync(request).ToActionResult();

        public async Task<ActionResult<TResult>> SendCommandAsync<TResult>(ICommand<TResult> request)
            => await this._commandMediator.SendAsync(request).ToActionResult();

        public Task<ActionResult> SendCommandAsync(ICommand<Result> request)
            => this._commandMediator.SendAsync(request).ToActionResult();

        public async Task<ActionResult<TResult>> SendCommandAsync<TResult>(ICommand<Result<TResult>> request)
            => await this._commandMediator.SendAsync(request).ToActionResult();
    }
}
