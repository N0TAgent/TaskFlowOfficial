using Microsoft.EntityFrameworkCore;
using TaskFlow.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контекст базы данных SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем контроллеры
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
