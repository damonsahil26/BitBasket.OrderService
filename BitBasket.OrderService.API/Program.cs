using BitBasket.OrderService.Business;
using BitBasket.OrderService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRequiredBusinessServices();

builder.Services.AddRequiredDataAccessServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
