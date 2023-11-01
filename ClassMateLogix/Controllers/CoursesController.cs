using BusinessLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ClassMateLogix.Controllers
{
    /// <summary>
    /// Controller for managing courses.
    /// </summary>
    /// 
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        /// <summary>
        /// Constructor for CoursesController.
        /// </summary>
        /// <param name="courseService">The course service to be injected.</param>
        /// 
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Get a list of all courses.
        /// </summary>
        /// <returns>An action result containing a list of courses or a 404 Not Found response.</returns>
        [HttpGet("getcourses")]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                var courses = await _courseService.GetAllCourses();

                if (courses != null)
                    return Ok(courses);

                return NotFound("Course Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get a course by its ID.
        /// </summary>
        /// <param name="courseId">The ID of the course to retrieve.</param>
        /// <returns>An action result containing the course or a 404 Not Found response.</returns>
        [HttpGet("getCourse/{courseId}")]
        public async Task<IActionResult> GetCourse(int courseId)
         {
            try
            {
                var course = await _courseService.GetCourseById(courseId);

                if (course != null)
                    return Ok(course);

                return NotFound("Course Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new course.
        /// </summary>
        /// <param name="course">The course data to be created.</param>
        /// <returns>An action result indicating success or a 400 Bad Request response for invalid data.</returns>
        [HttpPost("createcourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO course)
        {
            try
            {
                if (course == null)
                    return BadRequest("Invalid course data.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _courseService.CreateCourse(course);

                return CreatedAtAction("GetCourse", new { courseId = course.Id }, course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Update an existing course.
        /// </summary>
        /// <param name="courseId">The ID of the course to update.</param>
        /// <param name="course">The updated course data.</param>
        /// <returns>An action result indicating success or a 400 Bad Request response for invalid data.</returns>
        [HttpPut("updatecourse/{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] CourseDTO course)
        {
            try
            {
                if (course == null)
                    return BadRequest("Invalid course data.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (courseId != course.Id)
                    return BadRequest();

                await _courseService.UpdateCourse(course);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            
        }

        /// <summary>
        /// Delete a course by its ID.
        /// </summary>
        /// <param name="courseId">The ID of the course to delete.</param>
        /// <returns>An action result indicating success or a 400 Bad Request response for errors.</returns>
        [HttpDelete("deletecourse/{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            try
            {
                await _courseService.DeleteCourse(courseId);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }
    }
}
