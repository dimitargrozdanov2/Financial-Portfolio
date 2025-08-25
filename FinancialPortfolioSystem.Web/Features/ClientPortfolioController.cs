using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.SellAsset;
using FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Holdings;
using FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Metrics;
using FinancialPortfolioSystem.Web.Common;
using FinancialPortfolioSystem.Web.Façade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolioSystem.Web.Features;

public class ClientPortfolioController(IAppMediator mediator) : ApiController(mediator)
{
    [HttpPost]
    [Route("buy")]
    [Authorize(Roles = "Client")]
    public async Task<ActionResult> Buy(BuyClientAssetCommand command)
        => await SendAsync(command);

    [HttpPost]
    [Route("sell")]
    [Authorize(Roles = "Client")]
    public async Task<ActionResult> Sell(SellClientAssetCommand command)
        => await SendAsync(command);

    [HttpGet]
    [Authorize(Roles = "Client")]
    public async Task<ActionResult<AllClientAssetsOutputModel>> Holdings([FromQuery] GetPortfolioHoldingsQuery query)
         => await SendAsync(query);

    [HttpGet]
    [Route("metrics")]
    [Authorize(Roles = "Client")]
    public async Task<ActionResult<PortfolioMetricsOutputModel>> Metrics([FromQuery] GetPortfolioMetricsQuery query)
        => await SendAsync(query);
}
