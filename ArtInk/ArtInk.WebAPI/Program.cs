using ArtInk.Infraestructure.Configuration;
using ArtInk.Application.Configuration;
using ArtInk.WebAPI.Configuration;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure Infrastructure
builder.Services.ConfigureInfraestructure();

//Configure Application, Mapper and Fluent Validation
builder.Services.ConfigureApplication();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureFluentValidation();

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

var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.ConfigureExceptionHandler(logger);

app.Run();
