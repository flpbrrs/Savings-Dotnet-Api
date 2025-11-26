using Savings.Exceptions.Bases;
using System.Net;

namespace Savings.Exceptions;

public class ResourceNotFoundException(
    string resource,
    object id
) : SavingsException(ResourceErrorMessages.RESOURCE_NOT_FOUND)
{
    public override int StatusCode => (int) HttpStatusCode.NotFound;

    public override List<string> GetErrorList()
    {
        return [$"{resource}-with-id-{id}"];
    }
}
