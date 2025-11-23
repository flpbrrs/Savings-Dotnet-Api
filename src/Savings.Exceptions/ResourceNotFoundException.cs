using Savings.Exceptions.Bases;

namespace Savings.Exceptions;

public class ResourceNotFoundException(string resource, object id) : SavingsException("Recurso não encontrado na aplicação")
{
    public string Resource { get; set; } = $"{resource}-with-id-{id}";
}
