var builder = WebApplication.CreateBuilder(args);

// Configure
var app = builder.Build();

app.UseHttpsRedirection();

// Run
app.Run();