using MediatR;

namespace Hypesoft.Application.Features.UserFeatures.Add
{
    public sealed record AddUserRequest(string Email, string Name) : IRequest<AddUserResponse>;
}
