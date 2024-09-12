using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services for dependency injection
builder.Services.AddDbContext<CampingDbContext>(options =>
    // Retrieves the connection string from appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the UserService for dependency injection
builder.Services.AddScoped<UserService>();  

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
