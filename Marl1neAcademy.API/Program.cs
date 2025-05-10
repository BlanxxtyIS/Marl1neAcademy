using Marl1neAcademy.PostgreSQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("PostgreDbContext");
builder.Services.AddDbContext<PostgreDbContext>(
    options =>
    {
        options.UseNpgsql(connString);
    });

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
