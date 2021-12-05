using MiCake;
using Microsoft.EntityFrameworkCore;
using NoInvolution.MassageShop.EntityFramework;
using NoInvolution.MassageShop.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.

Configure(app);

app.MapControllers();
app.Run();


void ConfigureServices(WebApplicationBuilder webBuilder)
{
    // Add EFCore
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    webBuilder.Services.AddDbContext<MassageDbContext>(options =>
    {
        options.UseNpgsql(webBuilder.Configuration.GetConnectionString("Postgre"));
    });

    webBuilder.AddMiCakeServices();
    webBuilder.AddAppCoreServices();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MassageShop v1"));
    }

    app.UseAuthorization();
    var corsUrl = app.Configuration.GetSection("CORSUrl").Get<List<string>>() ?? new List<string>();
    app.UseCors(builder => builder.WithOrigins(corsUrl.ToArray())
                                  .SetIsOriginAllowedToAllowWildcardSubdomains()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader()
                                  .AllowCredentials());

    app.StartMiCake();
}