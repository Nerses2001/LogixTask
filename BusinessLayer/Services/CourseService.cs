using AutoMapper;
using BusinessLayer.IServices;
using DataLayer.IRepository;
using Entity;
using Model;

namespace BusinessLayer.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;
        public CourseService(ICoursesRepository coursesRepository, IMapper mapper)
        {
            this._coursesRepository = coursesRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {

            var courses = await _coursesRepository.GetAllCourses();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> GetCourseById(int courseId)
        {
            var course = await _coursesRepository.GetCourseById(courseId);
            return _mapper.Map<CourseDTO>(course);

        }

        public async Task CreateCourse(CourseDTO course)
        {
            var model = _mapper.Map<Course>(course);
            await _coursesRepository.CreateCourse(model);
        }

        public async Task UpdateCourse(CourseDTO course)
        {
            var model = _mapper.Map<Course>(course);
            await _coursesRepository.UpdateCourse(model);
        }

        public async Task DeleteCourse(int courseId)
        {
            await _coursesRepository.DeleteCourse(courseId);
        }
    }
}
