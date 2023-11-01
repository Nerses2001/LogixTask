using BusinessLayer.IServices;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace ClassMateLogix.Controllers
{
    /// <summary>
    /// Controller for managing user course assignments.
    /// </summary>
    [Route("api/usercourses")]
    [ApiController]
    public class UserCoursesController : ControllerBase
    {
        private readonly IUserCourseService _userCourseService;

        /// <summary>
        /// Constructor for UserCoursesController.
        /// </summary>
        /// <param name="userCourseService">The user course service to be injected.</param>
        public UserCoursesController(IUserCourseService userCourseService)
        {
            _userCourseService = userCourseService;
        }

        /// <summary>
        /// Assign a course to a user by their user ID.
        /// </summary>
        /// <param name="userId">The ID of the user to whom the course is assigned.</param>
        /// <param name="courseId">The ID of the course to be assigned.</param>
        /// <returns>An action result indicating success or failure of the assignment.</returns>
        [Route("{userId}/assign/{courseId}")]
        [HttpPost]
        public async Task<IActionResult> AssignCourseToUser(string userId, int courseId)
        {
            try
            {
                await _userCourseService.AssignCourseToUser(userId, courseId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get courses assigned to a user by their email.
        /// </summary>
        /// <param name="email">The email of the user for whom courses are to be retrieved.</param>
        /// <returns>An action result containing the courses assigned to the user or an error message if not found.</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCourses(string email)
        {
            try
            {
                var userCourses = await _userCourseService.GetUserCoursesByUserEmail(email);
                return Ok(userCourses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Unassign a course from a user by their user ID.
        /// </summary>
        /// <param name="userId">The ID of the user from whom the course is unassigned.</param>
        /// <param name="courseId">The ID of the course to be unassigned.</param>
        /// <returns>An action result indicating success or failure of the unassignment.</returns>
        [HttpDelete("{userId}/unassign/{courseId}")]
        public async Task<IActionResult> UnassignCourseFromUser(string userId, int courseId)
        {
            try
            {
                await _userCourseService.UnassignCourseFromUser(userId, courseId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
