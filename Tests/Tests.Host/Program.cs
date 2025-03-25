using System.Reflection;

using Nevermindjq.Payments.CryptoPay.Extensions;
using Nevermindjq.Telegram.Bot.Extensions;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
			 .WriteTo.Console()
			 .MinimumLevel.Information()
			 .CreateLogger();

builder.Services.AddSerilog(Log.Logger);
builder.Services.AddControllers();

builder.Services.AddCryptoPay(builder.Configuration["Payments:CryptoPay:Token"]!, builder.Configuration["Payments:CryptoPay:Network"]);
builder.Services.AddTelegramBot(Assembly.GetExecutingAssembly(), builder.Configuration["Bot:Token"]);

// Configure
var app = builder.Build();

app.UseCryptoPay();
app.MapControllers();

// Run
app.Run();