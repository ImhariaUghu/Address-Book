using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AddressAPI.Data;
using AddressAPI.Data.Repositories;
using AddressAPI.Models;
using AddressAPI.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AddressContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICrudRepository<AddressItem, int>, AddressRepository>();
builder.Services.AddScoped<ICrudService<AddressItem, int>, AddressService>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AddressRestAPI",
        Version =
    "v1"
    });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);//To EnableCors - CrossOrigin

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
