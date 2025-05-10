using BitBasket.OrderService.API.Middlewares;
using BitBasket.OrderService.Business;
using BitBasket.OrderService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddRequiredBusinessServices();

builder.Services.AddRequiredDataAccessServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
