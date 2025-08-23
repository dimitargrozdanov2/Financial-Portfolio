using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets
{
    public interface IAssetRepository : IAggregateRoot
    {
        //TO DO: Да си сложа interface на репозитори с AggregateRoot просто и да го регистрирам и него автоматично в стартъпа, правейки регистрацията дженерик

        Task<AllAssetsOutputModel> GetAll(CancellationToken cancellationToken = default);
        Task Create(Asset asset, CancellationToken cancellationToken = default);
        Task<Asset> GetById(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Asset asset, CancellationToken cancellationToken = default);
    }
}
