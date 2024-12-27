using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt=>opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductService,ProductService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options=> options.SwaggerEndpoint("/openapi/v1.json","WebApp"));
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();


