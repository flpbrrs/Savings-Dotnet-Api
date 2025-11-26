using Savings.Exceptions.Bases;
using System.Net;

namespace Savings.Exceptions;

public class ValidationException(List<string> errors) : SavingsException(ResourceErrorMessages.VALIDATION_ERROR)
{
    private readonly List<string> _errors = errors;

    public override int StatusCode => (int) HttpStatusCode.BadRequest;

    public override List<string> GetErrorList()
    {
        return _errors;
    }
}