using FinancialPortfolioSystem.Application.Features;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Delete;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Update;
using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Web.Common;
using FinancialPortfolioSystem.Web.Façade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolioSystem.Web.Features;

public class AssetsController(IAppMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    [Authorize(Roles = "Admin,Client")]
    public async Task<ActionResult<AllAssetsOutputModel>> GetAll([FromQuery] GetAllAssetsQuery query)
        => await SendAsync(query);

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<CreatedAssetOutputModel>> Create(CreateAssetCommand command)
        => await SendAsync(command);

    [HttpPut]
    [Route(Id)]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Edit(int id, UpdateAssetCommand command)
        => await SendAsync(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Remove(int id, [FromRoute] DeleteAssetCommand command)
        => await SendAsync(command.SetId(id));
}
