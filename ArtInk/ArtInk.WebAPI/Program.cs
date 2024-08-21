using ArtInk.Infraestructure.Configuration;
using ArtInk.Application.Configuration;
using ArtInk.WebAPI.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ArtInk.Utils.Converter;
using ArtInk.WebAPI.Authorization;
using ArtInk.WebAPI.Swagger;

var ArtInkSpecificOrigins = "_artInkSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
                                                    {
                                                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                                                        options.SerializerSettings.Converters.Add(new DateOnlyJsonConverter());
                                                        options.SerializerSettings.Converters.Add(new TimeOnlyJsonConverter());
                                                    });

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("ArtInk", p =>
    {
        p.RequireAuthenticatedUser();
        p.AddRequirements(new IdentifiedUser());
        p.Build();
    });
});

//Configure api versioning
builder.Services.ConfigureApiVersioning();

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

//Configure Infrastructure IoC
builder.Services.ConfigureInfraestructure();

//Configure Application, Mapper and Fluent Validation
builder.Services.ConfigureApplication();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureFluentValidation();

builder.Services.ConfigureSwagger();

//Configure database 
builder.Services.ConfigureDataBase(configuration);

//Configure authentication
builder.Services.ConfigureAuthentication(configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ArtInkSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:44378",
                                            "http://localhost:5000",
                                            "https://localhost:44378",
                                            "https://localhost:5000",
                                            "https://localhost:5191",
                                            "http://localhost:5191",
                                            "http://artink.tryasp.net/").AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.LoadSwagger();

app.UseHttpsRedirection();

app.UseCors(ArtInkSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.ConfigureExceptionHandler(logger);

await app.RunAsync();