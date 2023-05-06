using AwesomeChilli.API.DataMappers;
using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddSingleton<Database>();
builder.Services.AddDbContext<Database>(ServiceLifetime.Singleton);
builder.Services.AddTransient<IRepository<CategoryEntity>, CategoryRepository>();
builder.Services.AddTransient<IRepository<CommodityEntity>, CommodityRepository>();
builder.Services.AddTransient<IRepository<ManufacturerEntity>, ManufacturerRepository>();
builder.Services.AddTransient<IRepository<ReviewEntity>, ReviewRepository>();
builder.Services.AddTransient(typeof(Mapper<,>));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
