using AutoMapper;
using Entity;

namespace Model.Mapper
{
    public class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
           CreateMap<ApplicationUser, ProfileDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DataOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

           CreateMap<ProfileDTO, ApplicationUser>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DataOfBirth));

        }

    }
}
