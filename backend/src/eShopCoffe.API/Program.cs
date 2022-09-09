using eShopCoffe.API.Scope;
using eShopCoffe.API.Scope.Extensions;
using eShopCoffe.Context.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEShopCoffeControllers();
builder.Services.AddEShopCoffeSwagger();
builder.Services.AddEShopCoffeAuthentication();

EShopCoffeApiBootStrapper.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.UseIdentityAuthentication();
app.UseIdentitySwagger();

app.Services.InitializeDatabase();
app.Services.SeedData();

app.Run();
