using ArtInk.Infraestructure.Configuration;
using ArtInk.Application.Configuration;
using ArtInk.WebAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration= builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure Infrastructure
builder.Services.ConfigureInfraestructure();

//Configure Application and Mapper
builder.Services.ConfigureApplication();
builder.Services.ConfigureAutoMapper();

//Configure database 
builder.Services.ConfigureDataBase(configuration);

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
