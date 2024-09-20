using Microsoft.AspNetCore.Mvc;

namespace MMME.Api;

public class Program
{
    public static void Main(string[] args)
    {
        // The following is your fairly bulk-standard MVC type WEB API builder.

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}