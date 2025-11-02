using Microsoft.EntityFrameworkCore;
using Squares.Application;
using Squares.Infrastructure;
using Squares.Infrastructure.Data;
using Squares.Server.Filters;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Development");
builder.Services.ConfigureInfrastructure(connectionString);
builder.Services.ConfigureApplication();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<NotFoundExceptionFilter>();
    opt.Filters.Add<ValidationExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var squaresContext = scope.ServiceProvider.GetRequiredService<SquaresContext>();
    await squaresContext.Database.MigrateAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
