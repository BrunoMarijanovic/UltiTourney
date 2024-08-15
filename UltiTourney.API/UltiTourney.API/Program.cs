using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using UltiTourney.API.Data;
using UltiTourney.API.Mappings;
using UltiTourney.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// View local images
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject DB Context
builder.Services.AddDbContext<UltiTourneyDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("UltiTourneyConnectionString"))
    );

builder.Services.AddScoped<ICityRepository, SQLCityRepository>();
builder.Services.AddScoped<ICountryRepository, SQLCountryRepository>();
builder.Services.AddScoped<IImageRepository, LocalImageRepository>();
builder.Services.AddScoped<ITourneyRepository, SQLTourneyRepository>();

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

// Show sotred images from folder "./Images"
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});

app.MapControllers();

app.Run();
