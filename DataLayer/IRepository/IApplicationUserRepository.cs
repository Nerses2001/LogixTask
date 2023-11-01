using Entity;
using static DataLayer.IRepository.IRepositoryBase;

namespace DataLayer.IRepository
{
    /// <summary>
    /// Interface for managing application user data access operations.
    /// </summary>
    public interface IApplicationUserRepository : IRepositoryBase<ApplicationUser>
    {
        /// <summary>
        /// Find an application user by their email.
        /// </summary>
        /// <param name="email">The email of the user to find.</param>
        /// <returns>The application user if found, or null if not found.</returns>
        Task<ApplicationUser> FindByEmailAsync(string email);

        /// <summary>
        /// Find an application user by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the user to find.</param>
        /// <returns>The application user if found, or null if not found.</returns>
        Task<ApplicationUser> FindByPhoneAsync(string phoneNumber);

        /// <summary>
        /// Find all application users.
        /// </summary>
        /// <returns>An enumerable of application users or an empty enumerable if no users found.</returns>
        Task<IEnumerable<ApplicationUser>> FindAllAsync();

        /// <summary>
        /// Create a new application user.
        /// </summary>
        /// <param name="user">The application user to create.</param>
        /// <returns>An async task representing the operation.</returns>
        Task CreateUserAsync(ApplicationUser user);

        /// <summary>
        /// Remove an application user by their email.
        /// </summary>
        /// <param name="email">The email of the user to remove.</param>
        /// <returns>An async task representing the operation.</returns>
        Task RemoveUserAsync(string email);

        /// <summary>
        /// Edit an existing application user.
        /// </summary>
        /// <param name="user">The application user to edit.</param>
        /// <returns>An async task representing the operation.</returns>
        Task EditUserAsync(ApplicationUser user);
    }
}
