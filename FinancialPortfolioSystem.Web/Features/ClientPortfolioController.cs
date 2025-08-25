using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.SellAsset;
using FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Holdings;
using FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Metrics;
using FinancialPortfolioSystem.Web.Common;
using FinancialPortfolioSystem.Web.Façade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolioSystem.Web.Features;

public class ClientPortfolioController : ApiController
{
    public ClientPortfolioController(IAppMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Adds an asset to a client portfolio or updates its existing quantity.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("buy")]
    [Authorize(Roles = "Client")]
    public async Task<ActionResult> Buy(BuyClientAssetCommand command)
        => await this.SendAsync(command);

    /// <summary>
    /// Sells an asset from a client portfolio.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("sell")]
    [Authorize(Roles = "Client")]
    public async Task<ActionResult> Sell(SellClientAssetCommand command)
        => await this.SendAsync(command);

    /// <summary>
    /// Shows list of holdings with total value
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = "Client")]
    public async Task<ActionResult<AllClientAssetsOutputModel>> Holdings([FromQuery] GetPortfolioHoldingsQuery query)
         => await this.SendAsync(query);


    /// <summary>
    /// Shows Portfolio Metrics - Total invested amount, Current market value and Return on Investment(ROI)
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("metrics")]
    [Authorize(Roles = "Client")]
    public async Task<ActionResult<PortfolioMetricsOutputModel>> Metrics([FromQuery] GetPortfolioMetricsQuery query)
        => await this.SendAsync(query);
}
