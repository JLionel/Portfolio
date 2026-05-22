using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using portfolio.backend.Scripts.Data.Next_Tuto;
using Scalar.AspNetCore;

namespace portfolio.backend;


public partial class Program
{
    public static void Main(string[] args)
    {
        var localDev = Environment.GetEnvironmentVariable("IS_LOCAL_DEV");

        // load the .env file when running the server in local
        if (localDev == "true")
            Env.Load();
        
        var isDocker = Environment.GetEnvironmentVariable("IS_DOCKER");
        var isDev = Environment.GetEnvironmentVariable("IS_DEV");
        
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddProblemDetails();

        builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddCors(options =>
        {
            var origins = isDocker=="true"? "http://frontend:3000" : "http://localhost:3000";
            options.AddPolicy("AllowFrontend",
                policy => policy
                    .WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
        
        builder.Services.AddDbContext<AppDbNextTutoContext>(options =>
            options.UseNpgsql(GetConnectionString(isDocker, isDev)).LogTo(Console.WriteLine, LogLevel.Information));

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseExceptionHandler();

        app.UseHttpsRedirection();
        app.UseCors("AllowFrontend");
        app.MapControllers();

        // Only migrate using this function if the app is running in dev mode
        // In Production: see the service "Migration" from the docker compose file.
        // It uses the command "dotnet ef migrations bundle..." (see Docker.dockerfile/Migration/Dockerfile) 
        if(localDev == "true")
            MigrateDatabaseLocal(app);

        app.Run();
    }

    private static string GetConnectionString(string? isDocker, string? isDev)
    {
        var host = isDocker=="true"? Environment.GetEnvironmentVariable("DB_HOST_DOCKER") : Environment.GetEnvironmentVariable("DB_HOST");
        
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var password = isDev=="true"? Environment.GetEnvironmentVariable("DB_PASSWORD") : Environment.GetEnvironmentVariable("DB_PASSWORD_FILE");
        var database = Environment.GetEnvironmentVariable("NEXT_TUTO_DB_NAME");


        if (File.Exists(password)) // Check if it's a path to a secret file
        {
            password = File.ReadAllText(password).Trim();
        }

        return $"Host={host};Port={port};Database={database};Username={user};Password={password};";
    }

    
    private static void MigrateDatabaseLocal(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();

        var retries = 3;
    
        while (retries > 0)
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbNextTutoContext>();
            try
            {
                logger.LogInformation("Attempting to apply migrations...");
                db.Database.Migrate(); 
                
                logger.LogInformation("Migrations applied successfully");
                break;
            }
            catch
            {
                retries--;
                if (retries == 0)
                {
                    logger.LogCritical("Failed to apply migrations after 3 attempts");
                    break;
                }
                logger.LogWarning("Failed to apply migrations, retrying in 3 seconds...");
                Thread.Sleep(3000);
            }
        }
    }
}