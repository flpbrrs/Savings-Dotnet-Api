
using Savings.Api.Filters;
using Scalar.AspNetCore;

namespace Savings.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddMvc(opt => opt.Filters.Add<ExceptionFilter>());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
