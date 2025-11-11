using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Hypesoft.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = configuration["Swagger:Title"] ?? "MongoDb Clean Architecture API",
                    Version = "v1",
                    Description = configuration["Swagger:Description"] ?? "API Documentation for MongoDB Clean Architecture Project",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohaned Zekry",
                        Email = "mohanedzekry@outlook.com",
                        Url = new Uri("https://github.com/MohanedZekry")
                    }
                });
            });
        }
        public static void SwaggerConfig(this IApplicationBuilder app, IConfiguration configuration, string swaggerConfigName = "SwaggerConfig")
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string endPoint = configuration[$"{swaggerConfigName}:EndPoint"] ?? "/swagger/v1/swagger.json";
                string title = configuration[$"{swaggerConfigName}:Title"] ?? "API Documentation";

                c.SwaggerEndpoint(endPoint, title);
                c.DocumentTitle = $"{title} Documentation";
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
