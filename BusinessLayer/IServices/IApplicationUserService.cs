using Entity;
using Microsoft.AspNetCore.Identity;
using Model;

namespace BusinessLayer.IServices
{
    /// <summary>
    /// Interface for managing application user services.
    /// </summary>
    public interface IApplicationUserService
    {
        /// <summary>
        /// Get an application user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The application user if found, or null if not found.</returns>
        Task<ApplicationUser> GetById(string id);

        /// <summary>
        /// Find an application user by their email.
        /// </summary>
        /// <param name="email">The email of the user to find.</param>
        /// <returns>The application user DTO if found, or null if not found.</returns>
        Task<ApplicationUserDTO> FindByEmailAsync(string email);

        /// <summary>
        /// Find an application user by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the user to find.</param>
        /// <returns>The application user DTO if found, or null if not found.</returns>
        Task<ApplicationUserDTO> FindByPhoneAsync(string phoneNumber);

        /// <summary>
        /// Remove an application user by their email.
        /// </summary>
        /// <param name="email">The email of the user to remove.</param>
        /// <returns>An async task representing the operation.</returns>
        Task RemoveUserAsync(string email);

        /// <summary>
        /// Register a new user with the provided registration data.
        /// </summary>
        /// <param name="registrationDto">The registration data for the new user.</param>
        /// <returns>An identity result representing the success or failure of the registration.</returns>
        Task<IdentityResult> RegisterAsync(RegisterDTO registrationDto);

        /// <summary>
        /// Get the profile of an application user by their email.
        /// </summary>
        /// <param name="email">The email of the user to retrieve the profile for.</param>
        /// <returns>The user's profile DTO if found, or null if not found.</returns>
        Task<ProfileDTO> GetProfileAsync(string email);

        /// <summary>
        /// Get information for all users.
        /// </summary>
        /// <returns>An enumerable of user profile DTOs or an empty enumerable if no users found.</returns>
        Task<IEnumerable<ProfileDTO>> GetAllUsersInformationAsync();

        /// <summary>
        /// Edit the profile of an application user by their email.
        /// </summary>
        /// <param name="email">The email of the user to edit the profile for.</param>
        /// <param name="profileDTO">The profile data to update.</param>
        /// <returns>An async task representing the operation.</returns>
        Task EditUserAsync(string email, ProfileDTO profileDTO);
    }
}
