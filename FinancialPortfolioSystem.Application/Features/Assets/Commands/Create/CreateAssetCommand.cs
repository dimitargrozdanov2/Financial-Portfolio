using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using LiteBus.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Create
{
    public class CreateAssetCommand : AssetCommand<CreateAssetCommand>, ICommand<CreatedAssetOutputModel>
    {
    }
}
