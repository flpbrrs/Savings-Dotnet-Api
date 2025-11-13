namespace Savings.Exceptions;

public class ValidationException(List<string> errors) : Exception("Um ou mais erros de validação ocorreram")
{
    public readonly List<string> Errors = errors;
}