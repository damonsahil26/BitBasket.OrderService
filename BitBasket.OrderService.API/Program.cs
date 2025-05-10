using BitBasket.OrderService.Business;
using BitBasket.OrderService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRequiredBusinessServices();

builder.Services.AddRequiredDataAccessServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();
