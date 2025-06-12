using H2_skoleprojekt.Server.DB;
using H2_skoleprojekt.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Diagnostics.Eventing.Reader;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<String[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.WebHost.UseIISIntegration();

/*builder.WebHost.ConfigureKestrel(Options =>
{
    {
        Options.ListenLocalhost(5001);
    }
});*/
// Add services to the container.


var configuration = builder.Configuration;

string sqlServerConn = configuration.GetConnectionString("SqlServerConnection");
string postgresConn = configuration.GetConnectionString("PostgresConnection");

bool useSqlServer = false;

try
{
    using (var connection = new SqlConnection(sqlServerConn))
        {
        connection.Open();
        useSqlServer = true;
    }
}
catch
{
    Console.WriteLine("SQl Server not reachable. Falling back to local database.");
}

if (useSqlServer)
{
    builder.Services.AddDbContext<PlantDbContext>(options =>
    options.UseSqlServer(sqlServerConn));
}
else
{
    builder.Services.AddDbContext<PlantDbContext>(options =>
        options.UseNpgsql(postgresConn));
}

// Registers the assessment service
builder.Services.AddScoped<IAssessmentService, AssessmentService>();

builder.Services.AddScoped<IPlantDbRepository, PlantDbRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

var lifetime = app.Lifetime;
var endpointDataSource = app.Services.GetRequiredService<EndpointDataSource>();

lifetime.ApplicationStarted.Register(() =>
{
    foreach (var endpoint in endpointDataSource.Endpoints)
    {
        Console.WriteLine($"Endpoint: {endpoint.DisplayName}");
    }
});

app.Run();
