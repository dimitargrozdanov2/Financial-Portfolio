using FinancialPortfolioSystem.Application.Exceptions;
using FluentValidation;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Behaviours;

public class ValidationPreHandler<TCommand> : ICommandPreHandler<TCommand>
    where TCommand : class, ICommand
{
    private readonly IEnumerable<IValidator<TCommand>> _validators;

    public ValidationPreHandler(IEnumerable<IValidator<TCommand>> validators)
    {
        _validators = validators;
    }

    public Task PreHandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        if (!_validators.Any())
            return Task.CompletedTask;

        var context = new ValidationContext<TCommand>(command);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count > 0)
        {
            throw new ModelValidationException(failures);
        }

        return Task.CompletedTask;
    }
}