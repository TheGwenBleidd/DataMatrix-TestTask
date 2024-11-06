using Contacts.Api.Middlewares;
using Contacts.Application.Extensions;
using Contacts.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

if (dbContext != null && dbContext.Database.GetPendingMigrations().Any())
{
    dbContext.Database.Migrate();
}

app.Run();