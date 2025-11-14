namespace Savings.Comunication.Responses;

public class ApiErrorResponseJson(string? message, List<string> errors)
{
    public string? Message { get; set; } = message;
    public List<string> ErrorsCodes { get; set; } = errors;

    public ApiErrorResponseJson(string message) : this(message, ["unknow.error"]) {}
}
