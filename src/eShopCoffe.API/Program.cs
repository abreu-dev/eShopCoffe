using eShopCoffe.API.Scope;
using eShopCoffe.API.Scope.Extensions;
using eShopCoffe.Identity.Infra.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEShopCoffeControllers();
builder.Services.AddEShopCoffeSwagger();
builder.Services.AddEShopCoffeAuthentication(builder.Configuration);

EShopCoffeApiBootStrapper.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.UseIdentityAuthentication();
app.UseIdentitySwagger();

app.Services.SeedData();

app.Run();
