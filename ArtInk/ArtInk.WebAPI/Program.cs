using ArtInk.Infraestructure.Configuration;
using ArtInk.Application.Configuration;
using ArtInk.WebAPI.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ArtInk.Utils.Converter;

var ArtInkSpecificOrigins = "_artInkSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
                                                    {
                                                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                                                        options.SerializerSettings.Converters.Add(new DateOnlyJsonConverter());
                                                    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.ToString()));

//configure Infrastructure
builder.Services.ConfigureInfraestructure();

//Configure Application, Mapper and Fluent Validation
builder.Services.ConfigureApplication();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureFluentValidation();

//Configure database 
builder.Services.ConfigureDataBase(configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ArtInkSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:44378",
                                            "http://localhost:5000",
                                            "https://localhost:44378",
                                            "https://localhost:5000");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(ArtInkSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.ConfigureExceptionHandler(logger);

await app.RunAsync();