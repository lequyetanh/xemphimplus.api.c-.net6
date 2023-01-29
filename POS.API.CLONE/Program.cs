using Microsoft.EntityFrameworkCore;
using POS.API.CLONE.Entities;
using POS.API.CLONE.IRepositories;
using POS.API.CLONE.Repositories;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var contexOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(connectionString).Options;
builder.Services.AddDbContext<ApplicationContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddTransient<CountryIRepositories, CountryRepositories>();
builder.Services.AddTransient<UserIRepositories, UserRepositories>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    //dataContext.Database.Migrate(); //auto migration database
}

app.MapControllers();

app.Run();
