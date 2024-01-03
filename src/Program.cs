var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", (IConfiguration configuration) => configuration["Enviroment"]);
app.Run();
