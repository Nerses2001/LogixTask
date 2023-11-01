using DataLayer.IRepository;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository
{
    public class UserCourseRepository : RepositoryBase<UserCourse>, IUserCourseRepository
    {
        public UserCourseRepository(DataBaseContext context) : base(context)
        {

        }

        public async Task AssignCourseToUser(string userId, int courseId)
        {
            var userCourse = new UserCourse
            {
                UserEmail = userId,
                CourseId = courseId
            };

            await _context.UserCourses.AddAsync(userCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserCourse>> GetUserCoursesByUserId(string email)
        {
            return await _context.UserCourses.Where(uc => uc.UserEmail == email).ToListAsync();
        }

        public async Task UnassignCourseFromUser(string eamil, int courseId)
        {
            var userCourse = await _context.UserCourses
                .FirstOrDefaultAsync(uc => uc.UserEmail == eamil && uc.CourseId == courseId);

            if (userCourse != null)
            {
                _context.UserCourses.Remove(userCourse);
                await _context.SaveChangesAsync();
            }
        }

    }
}
