using Entity;

namespace DataLayer.IRepository
{
    /// <summary>
    /// Interface for managing user course data access operations.
    /// </summary>
    public interface IUserCourseRepository
    {
        /// <summary>
        /// Get user courses by user email.
        /// </summary>
        /// <param name="email">The email of the user to retrieve courses for.</param>
        /// <returns>An enumerable of user courses or an empty enumerable if no courses found.</returns>
        Task<IEnumerable<UserCourse>> GetUserCoursesByUserId(string email);

        /// <summary>
        /// Assign a course to a user by email and course ID.
        /// </summary>
        /// <param name="email">The email of the user to whom the course is assigned.</param>
        /// <param name="courseId">The ID of the course to be assigned.</param>
        /// <returns>An async task representing the operation.</returns>
        Task AssignCourseToUser(string email, int courseId);

        /// <summary>
        /// Unassign a course from a user by email and course ID.
        /// </summary>
        /// <param name="email">The email of the user from whom the course is unassigned.</param>
        /// <param name="courseId">The ID of the course to be unassigned.</param>
        /// <returns>An async task representing the operation.</returns>
        Task UnassignCourseFromUser(string email, int courseId);
    }
}
