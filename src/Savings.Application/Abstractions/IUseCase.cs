namespace Savings.Application.Abstractions;

public interface IUseCase<TRequest, TResponse>
{
    Task<TResponse> Execute(TRequest request);
}
public struct Empty { public static Empty Value => default; }