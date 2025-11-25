namespace Savings.Domain.Exceptions;

public class DomainException(string message) : SystemException(message) { }
