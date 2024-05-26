using GestorDeTurnos.API.Middlewares;
using GestorDeTurnos.Application;
using GestorDeTurnos.Application.Setups;
using GestorDeTurnos.Identity;
using GestorDeTurnos.Persistence;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var cultureInfo = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddApplicationLayerServices(configuration);
builder.Services.AddPersistenceLayerServices(configuration);
builder.Services.AddIdentityLayerServices(configuration);
builder.Host.UseSerilog(SeriLogSetup.Configure);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();