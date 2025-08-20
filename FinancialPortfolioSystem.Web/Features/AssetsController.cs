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

        [HttpGet]
        public async Task<ActionResult<AllAssetsOutputModel>> GetAll([FromQuery] GetAllAssetsQuery query)
            => await this.SendAsync(query);

        [HttpPost]
//        [Authorize]
        public async Task<ActionResult<CreatedAssetOutputModel>> Create(CreateAssetCommand command)
            => await this.SendAsync(command);
    }
}
