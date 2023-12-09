using Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace rest_api_test;

public class Program
{
    public static void Main(string[] args) {

        Console.WriteLine("Starting up webapi");

        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Services.AddHttpLogging(o => { });

        Console.WriteLine("Adding Controller routes");        

        builder.Services.AddControllers();

        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();



        var configuration = builder.Configuration;
        builder.Services.AddDbContext<BookContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DBCONN")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseSwagger();
        //     app.UseSwaggerUI();
        // }

        app.UseHttpLogging();

        app.UseHttpsRedirection();

        // app.UseAuthorization();

        app.MapControllers();

        app.MapGet("/api/ping", () => "pong");

        app.Run();
    }
}












