using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.CreateUser
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result>
    {
        private readonly IIdentity _identity;

        public CreateUserCommandHandler(IIdentity identity)
        {
            _identity = identity;
        }

        public async Task<Result> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken = default)
        {
            var result = await this._identity.Register(request);

            return result;
        }
    }
}
