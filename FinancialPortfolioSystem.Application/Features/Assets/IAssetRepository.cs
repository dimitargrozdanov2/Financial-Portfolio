using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets
{
    public interface IAssetRepository
    {
        Task<AllAssetsOutputModel> GetAll(CancellationToken cancellationToken = default);
    }
}
