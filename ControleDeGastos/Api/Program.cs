using Api.Helpers;
using Core.Extensions;
using IOC;
using IOC.Extensions;

var builder = WebApplication.CreateBuilder(args);
var _configuration = builder.Configuration;

var appAssemblies = AppHelpers.Assemblies;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddCore(appAssemblies)
    .AddEfCore(() => new Data.Settings.EfCoreSettings
    {
        ControleContasConnectionString = _configuration.GetConnectionString("ControleContasConnectionString")
    });

builder.Services.AddControllers(); // Trocar para extension

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
