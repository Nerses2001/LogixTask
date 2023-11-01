using AutoMapper;
using BusinessLayer.IServices;
using DataLayer.IRepository;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BusinessLayer.Services
{
    /// <summary>
    /// Service for managing application user operations.
    /// </summary>
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for ApplicationUserService.
        /// </summary>
        /// <param name="userManager">The UserManager for identity operations.</param>
        /// <param name="repository">The repository for application user data access.</param>
        /// <param name="mapper">The AutoMapper for mapping data transfer objects.</param>
        public ApplicationUserService(UserManager<ApplicationUser> userManager, IApplicationUserRepository repository, IMapper mapper)
        {
            this._userManager = userManager;
            this._repository = repository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Find a user by their email.
        /// </summary>
        /// <param name="email">The email of the user to find.</param>
        /// <returns>The application user DTO if found, or null if not found.</returns>
        public async Task<ApplicationUserDTO> FindByEmailAsync(string email)
        {
            var user = await _repository.FindByEmailAsync(email);
            return _mapper.Map<ApplicationUserDTO>(user);
        }

        /// <summary>
        /// Register a new user with the provided registration data.
        /// </summary>
        /// <param name="registrationDto">The registration data for the new user.</param>
        /// <returns>An identity result representing the success or failure of the registration.</returns>
        public async Task<IdentityResult> RegisterAsync(RegisterDTO registrationDto)
        {
            var user = _mapper.Map<ApplicationUser>(registrationDto);
            return await _userManager.CreateAsync(user);
        }

        /// <summary>
        /// Find a user by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the user to find.</param>
        /// <returns>The application user DTO if found, or null if not found.</returns>
        public async Task<ApplicationUserDTO> FindByPhoneAsync(string phoneNumber)
        {
            var user = await _repository.FindByPhoneAsync(phoneNumber);
            return _mapper.Map<ApplicationUserDTO>(user);
        }

        /// <summary>
        /// Remove a user by their email.
        /// </summary>
        /// <param name="email">The email of the user to remove.</param>
        /// <returns>An async task representing the operation.</returns>
        public async Task RemoveUserAsync(string email)
        {
            await _repository.RemoveUserAsync(email);
        }

        /// <summary>
        /// Get user profile by email.
        /// </summary>
        /// <param name="email">The email of the user to retrieve the profile for.</param>
        /// <returns>The user's profile DTO if found, or null if not found.</returns>
        public async Task<ProfileDTO> GetProfileAsync(string email)
        {
            var user = await _repository.FindByEmailAsync(email);
            if (user != null)
            {
                var profileDTO = _mapper.Map<ProfileDTO>(user);
                return profileDTO;
            }

            return null;
        }

        /// <summary>
        /// Get information for all users.
        /// </summary>
        /// <returns>An enumerable of user profile DTOs or an empty enumerable if no users found.</returns>
        public async Task<IEnumerable<ProfileDTO>> GetAllUsersInformationAsync()
        {
            var users = await _repository.FindAllAsync();

            return users.Select(user => new ProfileDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            });
        }

        /// <summary>
        /// Edit user profile by email.
        /// </summary>
        /// <param name="email">The email of the user to edit the profile for.</param>
        /// <param name="profileDTO">The profile data to update.</param>
        /// <returns>An async task representing the operation.</returns>
        public async Task EditUserAsync(string email, ProfileDTO profileDTO)
        {
            var user = await _repository.FindByEmailAsync(email);

            if (user != null)
            {
                var userDto = _mapper.Map<ApplicationUser>(profileDTO);

                await _repository.EditUserAsync(userDto);
            }
        }

        /// <summary>
        /// Get an application user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The application user if found, or null if not found.</returns>
        public async Task<ApplicationUser> GetById(string id)
        {
            var user = _userManager.Users.Include(i => i.Email).FirstOrDefault(x => x.Id == id);
            return user;
        }

    }
}
