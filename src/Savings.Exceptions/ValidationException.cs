using Savings.Exceptions.Bases;

namespace Savings.Exceptions;

public class ValidationException(List<string> errors) : SavingsException(ResourceErrorMessages.VALIDATION_ERROR)
{
    public readonly List<string> Errors = errors;
}