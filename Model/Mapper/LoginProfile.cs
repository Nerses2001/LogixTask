using AutoMapper;
using Entity;

namespace Model.Mapper
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<ApplicationUser, LoginDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<LoginDTO, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        }

    }
}
