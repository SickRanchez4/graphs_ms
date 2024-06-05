using graphs_ms.Data;
using graphs_ms.Interfaces;
using graphs_ms.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("StringSqlServer"));
});

builder.Services.AddScoped<IReportServices, ReportServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
