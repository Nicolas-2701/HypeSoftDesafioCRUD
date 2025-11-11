using AutoMapper;
using Hypesoft.Domain.Entities;

namespace Hypesoft.Application.Features.UserFeatures.Add
{
    public sealed class AddUserMapper : Profile
    {
        public AddUserMapper()
        {
            CreateMap<AddUserRequest, User>();
            CreateMap<User, AddUserResponse>();
        }
    }
}