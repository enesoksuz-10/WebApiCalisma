using North_Business.Abstract;
using North_Business.Concreate;
using North_Business.Mappers;
using North_DataAccess.Repository.Abstract;
using North_DataAccess.Repository.Concreate;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IProductRepository,ProductRepository>();
builder.Services.AddSingleton<IProductBS,ProductBS>();
//builder.Services.AddSingleton<IProductRepository,ProductRepoByAdoNet>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        //options.JsonSerializerOptions.MaxDepth = 0;
    });

builder.Services.AddAutoMapper(typeof(ProductProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
