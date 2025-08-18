using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Domain.Models.Assets;
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
        Task Create(Asset asset, CancellationToken cancellationToken = default);
    }
}
