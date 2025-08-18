using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features
{
    public static class EntityCommandExtensions
    {
        public static TCommand SetId<TCommand, TId>(this TCommand command, TId id)
            where TCommand : EntityCommand<TId>
        {
            command.Id = id;
            return command;
        }
    }
}
