using Hypesoft.Application;
using Hypesoft.Persistence;
using Hypesoft.API.Endpoints;
using Hypesoft.API.Extensions;
using Hypesoft.API.Extensions;

using Hypesoft.Application.Repository.ProductRepository;
using Hypesoft.Persistence.Repository.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication(); 
builder.Services.AddSwaggerConfiguration(builder.Configuration);

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureApiBehavior();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.SwaggerConfig(builder.Configuration, "SwaggerConfigTest");
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseErrorHandler();

app.MapUserEndpoints();
app.MapProductEndpoints(); 

app.Run();