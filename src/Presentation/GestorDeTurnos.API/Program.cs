using GestorDeTurnos.API.Middlewares;
using GestorDeTurnos.Application.Setups;
using GestorDeTurnos.Application;
using GestorDeTurnos.Identity;
using GestorDeTurnos.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configura la pol�tica CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Origen permitido
                   .AllowAnyHeader()   // Permite cualquier encabezado
                   .AllowAnyMethod();  // Permite cualquier m�todo
        });
});

// Agrega otros servicios
builder.Services.AddApplicationLayerServices(builder.Configuration);
builder.Services.AddPersistenceLayerServices(builder.Configuration);
builder.Services.AddIdentityLayerServices(builder.Configuration);
builder.Host.UseSerilog(SeriLogSetup.Configure);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowReactApp"); // Usa la pol�tica CORS definida
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
