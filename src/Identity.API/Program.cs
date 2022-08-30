using Identity.Api.Scope;
using Identity.Api.Scope.Extensions;
using Identity.Infra.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentityControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentitySwagger();
builder.Services.AddIdentityAuthentication(builder.Configuration);

IdentityApiBootStrapper.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.UseIdentityAuthentication();
app.UseIdentitySwagger();

app.Services.SeedData();

app.Run();
