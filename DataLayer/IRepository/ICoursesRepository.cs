using Entity;

namespace DataLayer.IRepository
{
    /// <summary>
    /// Interface for managing course data access operations.
    /// </summary>
    public interface ICoursesRepository
    {
        /// <summary>
        /// Get all courses.
        /// </summary>
        /// <returns>An enumerable of courses.</returns>
        Task<IEnumerable<Course>> GetAllCourses();

        /// <summary>
        /// Get a course by its ID.
        /// </summary>
        /// <param name="courseId">The ID of the course to retrieve.</param>
        /// <returns>The course if found, or null if not found.</returns>
        Task<Course> GetCourseById(int courseId);

        /// <summary>
        /// Create a new course.
        /// </summary>
        /// <param name="course">The course to create.</param>
        /// <returns>An async task representing the operation.</returns>
        Task CreateCourse(Course course);

        /// <summary>
        /// Update an existing course.
        /// </summary>
        /// <param name="course">The course to update.</param>
        /// <returns>An async task representing the operation.</returns>
        Task UpdateCourse(Course course);

        /// <summary>
        /// Delete a course by its ID.
        /// </summary>
        /// <param name="courseId">The ID of the course to delete.</param>
        /// <returns>An async task representing the operation.</returns>
        Task DeleteCourse(int courseId);
    }
}
