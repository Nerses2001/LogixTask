using AutoMapper;
using Entity;

namespace Model.Mapper
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseDTO, Course>()
                .ForMember(dest => dest.CourseApplicationUsers, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 

        }

    }
}
