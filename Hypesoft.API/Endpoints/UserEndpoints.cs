using Hypesoft.Application.Repository.UserRepository;
using Hypesoft.Domain.Entities;

namespace Hypesoft.API.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/users", async (User user, IUserRepository userRepository) =>
            {
                await userRepository.AddAsync(user);
                return Results.Created($"/users/{user.Id}", user);
            }).WithTags("Users");
        }
    }
}
