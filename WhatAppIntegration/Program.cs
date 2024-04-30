using WhatAppIntegration.Domain;

var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel
int port = int.Parse(args.Length > 0 ? args[0] : "5000");
builder.WebHost.UseKestrel(options => {
    options.ListenAnyIP(port); // Ou�a em todas as interfaces na porta especificada
});

var log = new LogDomain();
log.LogMessage("Inicio", "Inicio Controller");
// Adicionar servi�os ao container.
builder.Services.AddControllers();
// (Outras configura��es de servi�o)

log.LogMessage("Inicio", "Montagem");
var app = builder.Build();

// Configurar o pipeline HTTP request.
log.LogMessage("Inicio", "Configura http request");
app.MapControllers();

log.LogMessage("Inicio", "Iniciar");

app.Run();

