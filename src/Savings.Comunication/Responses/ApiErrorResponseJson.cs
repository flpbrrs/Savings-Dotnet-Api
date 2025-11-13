namespace Savings.Comunication.Responses;

public class ApiErrorResponseJson
{
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = [];
}
