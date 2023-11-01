using Entity;
using Model;

namespace BusinessLayer.IServices
{
    /// <summary>
    /// Interface for managing user course-related operations.
    /// </summary>
    public interface IUserCourseService
    {
        /// <summary>
        /// Assign a course to a user by their user ID.
        /// </summary>
        /// <param name="userId">The ID of the user to whom the course is assigned.</param>
        /// <param name="courseId">The ID of the course to be assigned.</param>
        /// <returns>An async task representing the operation.</returns>
        Task AssignCourseToUser(string userId, int courseId);

        /// <summary>
        /// Get courses assigned to a user by their email.
        /// </summary>
        /// <param name="email">The email of the user for whom courses are to be retrieved.</param>
        /// <returns>An enumerable of user course DTOs or an empty enumerable if no courses found.</returns>
        Task<IEnumerable<UserCourseDTO>> GetUserCoursesByUserEmail(string email);

        /// <summary>
        /// Unassign a course from a user by their email and course ID.
        /// </summary>
        /// <param name="email">The email of the user from whom the course is unassigned.</param>
        /// <param name="courseId">The ID of the course to be unassigned.</param>
        /// <returns>An async task representing the operation.</returns>
        Task UnassignCourseFromUser(string email, int courseId);
    }
}
