using FinancialPortfolioSystem.Application.Features;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.SellAsset;
using FinancialPortfolioSystem.Web.Common;
using FinancialPortfolioSystem.Web.Façade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Web.Features
{
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
        /// <param name="userId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("sell")]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> Sell(SellClientAssetCommand command)
            => await this.SendAsync(command);
    }
}
