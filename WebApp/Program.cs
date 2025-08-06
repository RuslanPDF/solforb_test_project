using System.Text.Json.Serialization;
using Application;
using Microsoft.EntityFrameworkCore;
using WebApp.Extensions;
using Persistence;
using WebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });

builder.Services.AddSwagger();

builder.Services.AddApplication(config);
builder.Services.AddPersistence(config);

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<PostgresqlDbContext>();
await dbContext.Database.MigrateAsync();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(_ => true));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();