using MediatR;
using Hypesoft.Application.Commands; 
using Hypesoft.Domain.Entities;
using Hypesoft.Application.Queries;

namespace Hypesoft.API.Endpoints
{

    public class UpdateProductRequest
    {
        public required string name { get; set; }
        public string? desc { get; set; }
        public required string category { get; set; }
        public int price { get; set; }
        public int amout { get; set; }
    }
    public static class ProductEndPoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {

            app.MapPost("/product", async (CreateProductCommand command, ISender sender) =>
            {
                Product productCreated = await sender.Send(command);
                return Results.Created($"/products/{productCreated.Id}", productCreated);
            }).WithTags("Products");

            app.MapGet("/product", async (ISender sender) =>
            {
                var query = new GetAllProductsQuery();
                var products = await sender.Send(query);
                return Results.Ok(products);
            }).WithTags("Products");

            app.MapGet("/product/{id}", async (string id, ISender sender) =>
            {
                var query = new GetProductByIdQuery { Id = id };
                var product = await sender.Send(query);
                return product != null ? Results.Ok(product) : Results.NotFound();
            }).WithTags("Products");

            app.MapGet("/product/search", async ([AsParameters] SearchProductsQuery query, ISender sender) =>
            {
                var products = await sender.Send(query);
                return Results.Ok(products);
            }).WithTags("Products");
            
            app.MapGet("/product/lowstock", async (ISender sender) =>
            {
                var query = new GetLowStockProductsQuery();
                var products = await sender.Send(query);
                return Results.Ok(products);
            }).WithTags("Products");

            app.MapPut("/product/{id}", async (string id, UpdateProductRequest requestBody, ISender sender) =>
            {
                var command = new UpdateProductCommand
                {
                    Id = id,
                    name = requestBody.name,
                    desc = requestBody.desc,
                    category = requestBody.category,
                    price = requestBody.price,
                    amout = requestBody.amout
                };
                
                var updatedProduct = await sender.Send(command);

                return updatedProduct != null ? Results.Ok(updatedProduct) : Results.NotFound();
            }).WithTags("Products");

            app.MapDelete("/product/{id}", async (string id, ISender sender) =>
            {
                var command = new DeleteProductCommand { Id = id };
                var success = await sender.Send(command);
                return success ? Results.NoContent() : Results.NotFound();
            }).WithTags("Products");
        }
    }
}