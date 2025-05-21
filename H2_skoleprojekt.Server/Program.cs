using H2_skoleprojekt.Server.DB;
using H2_skoleprojekt.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5172")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.WebHost.ConfigureKestrel(Options =>
{
    {
        Options.ListenLocalhost(5001);
        
        /* Noget af det kode kan bruges igen, når du skal skabe forbindelse til serveren!
        serverOptions.ListenAnyIP(5001, listenOptions =>
        {
            listenOptions.UseHttps();
        });
        Console.WriteLine("Https configured on port 5001.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to configured HTTPS: {ex.Message}");*/
    }
});
// Add services to the container.

builder.Services.AddDbContext<PlantDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

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

/*app.UseHttpsRedirection();  //Skal nok bruges igen når webserveren skal integreres. */

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
