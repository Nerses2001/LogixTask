using Entity;
using Model;

namespace BusinessLayer.IServices
{
    /// <summary>
    /// Interface for managing course-related operations.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Get all courses.
        /// </summary>
        /// <returns>An enumerable of course DTOs.</returns>
        Task<IEnumerable<CourseDTO>> GetAllCourses();

        /// <summary>
        /// Get a course by its ID.
        /// </summary>
        /// <param name="courseId">The ID of the course to retrieve.</param>
        /// <returns>The course DTO if found, or null if not found.</returns>
        Task<CourseDTO> GetCourseById(int courseId);

        /// <summary>
        /// Create a new course.
        /// </summary>
        /// <param name="course">The course DTO containing the data for the new course.</param>
        /// <returns>An async task representing the operation.</returns>
        Task CreateCourse(CourseDTO course);

        /// <summary>
        /// Update an existing course.
        /// </summary>
        /// <param name="course">The course DTO containing the updated data.</param>
        /// <returns>An async task representing the operation.</returns>
        Task UpdateCourse(CourseDTO course);

        /// <summary>
        /// Delete a course by its ID.
        /// </summary>
        /// <param name="courseId">The ID of the course to delete.</param>
        /// <returns>An async task representing the operation.</returns>
        Task DeleteCourse(int courseId);
    }
}
