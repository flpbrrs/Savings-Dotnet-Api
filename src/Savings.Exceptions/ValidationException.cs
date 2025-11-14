using Savings.Exceptions.Bases;

namespace Savings.Exceptions;

public class ValidationException(List<string> errors) : SavingsException("Um ou mais erros de validação ocorreram")
{
    public readonly List<string> Errors = errors;
}