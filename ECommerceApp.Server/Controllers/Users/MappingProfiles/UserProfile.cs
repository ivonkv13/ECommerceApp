using AutoMapper;
using ECommerceApp.Server.Controllers.Users.Dtos;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Server.Controllers.Users.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, IdentityUser>();
        }
    }
}
