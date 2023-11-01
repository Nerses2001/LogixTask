using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapper
{
    public class UserCourseProfile : Profile
    {
        public UserCourseProfile()
        {
            CreateMap<UserCourse, UserCourseDTO>();

            CreateMap<UserCourseDTO, UserCourse>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore())
                .ForMember(dest => dest.Course, opt => opt.Ignore());
;
        }
    }
}
