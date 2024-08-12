using Microsoft.EntityFrameworkCore;
using UltiTourney.API.Data;
using UltiTourney.API.Mappings;
using UltiTourney.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject DB Context
builder.Services.AddDbContext<UltiTourneyDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("UltiTourneyConnectionString"))
    );

builder.Services.AddScoped<ICityRepository, SQLCityRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
