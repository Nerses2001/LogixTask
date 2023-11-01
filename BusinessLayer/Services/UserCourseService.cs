using AutoMapper;
using BusinessLayer.IServices;
using DataLayer.IRepository;
using DataLayer.Repository;
using Entity;
using Model;

namespace BusinessLayer.Services
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IMapper _mapper;
        

        public UserCourseService(IUserCourseRepository userCourseRepository, IMapper mapper)
        {
            this._userCourseRepository = userCourseRepository;
            this._mapper = mapper;
        }

        public async Task AssignCourseToUser(string userId, int courseId)
        {
            await _userCourseRepository.AssignCourseToUser(userId, courseId);
        }

        public async Task<IEnumerable<UserCourseDTO>> GetUserCoursesByUserEmail(string email)
        {
            
            var userCources = await _userCourseRepository.GetUserCoursesByUserId(email);
            return _mapper.Map<IEnumerable<UserCourseDTO>>(userCources);


        }

        public async Task UnassignCourseFromUser(string email, int courseId)
        {
            await _userCourseRepository.UnassignCourseFromUser(email, courseId);
        }

    }
}
