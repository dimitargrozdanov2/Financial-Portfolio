using FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;
using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Web.Common;
using FinancialPortfolioSystem.Web.Façade;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolioSystem.Web.Features
{
    public class AssetsController : ApiController
    {
        public AssetsController(IAppMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Retrieves all assets based on the specified query parameters. These parameters will be added in a later version.
        /// </summary>
        /// <param name="query">The query object containing filtering, paging, or other parameters for fetching assets.</param>
        /// <returns>An <see cref="AllAssetsOutputModel"/> containing the list of assets and any relevant metadata.</returns>
        [HttpGet]
        public async Task<ActionResult<AllAssetsOutputModel>> GetAll([FromQuery] GetAllAssetsQuery query)
            => await this.SendAsync(query);

        /// <summary>
        /// Creates a new asset.
        /// Id parameter is ignored. AssetType values: 1 - Stock, 2 - ETF, 3 - Bond (required).
        /// </summary>
        /// <param name="command">The asset creation command.</param>
        /// <returns>The created asset.</returns>
        [HttpPost]
        //        [Authorize]
        public async Task<ActionResult<CreatedAssetOutputModel>> Create(CreateAssetCommand command)
            => await this.SendAsync(command);
    }
}
