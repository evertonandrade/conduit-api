using Conduit.Api.Config;
using Conduit.Api.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCqrs();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddJwtConfig(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(Startup.RegisterEndpoints);
app.UseHttpsRedirection();
app.Run();
