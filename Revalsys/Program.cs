using Microsoft.EntityFrameworkCore;
using Revalsys.Data;

var builder = WebApplication.CreateBuilder(args);

// Register Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Revalsys API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication(); // ✅ Ensure Authentication is called first
app.UseAuthorization();  // ✅ Authorization must come after Authentication

app.MapControllers();

app.Run();
