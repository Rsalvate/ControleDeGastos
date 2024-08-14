using Api.Helpers;
using Core.Extensions;
using IOC.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appAssemblies = AppHelpers.Assemblies;

builder.AddAutoMapper(appAssemblies);

builder.Services.AddControllers(); // Trocar para extension

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication(appAssemblies);

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
