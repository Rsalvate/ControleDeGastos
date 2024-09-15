using Api.Helpers;
using Core.Extensions;
using IOC.Extensions;

var builder = WebApplication.CreateBuilder(args);
var _configuration = builder.Configuration;

var appAssemblies = AppHelpers.Assemblies;

builder.AddAutoMapper(appAssemblies);

builder.Services.AddControllers(); // Trocar para extension

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication(appAssemblies)
    .AddEfCore(()=>new Data.Settings.EfCoreSettings
    {
        ControleContasConnectionString = _configuration.GetConnectionString("ControleContasConnectionString")
    });

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
