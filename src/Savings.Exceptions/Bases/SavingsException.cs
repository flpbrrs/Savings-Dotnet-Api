namespace Savings.Exceptions.Bases;

public abstract class SavingsException(string message) : SystemException(message) 
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrorList();
}
