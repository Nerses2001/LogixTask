using DataLayer.IRepository;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataLayer.Repository
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(DataBaseContext context) : base(context)
        {

        }

        // Create a new user
        public async Task CreateUserAsync(ApplicationUser user)
        {
            // Add the user to the database and save changes async
            await _context.ApplicationUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        // Edit an existing user
        public async Task EditUserAsync(ApplicationUser user)
        {
            // Mark the user as modified in the database and save changes async
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Find all users in the database
        public async Task<IEnumerable<ApplicationUser>> FindAllAsync()
        {
            // Retrieve all users from the database
            return await _context.ApplicationUsers.ToListAsync();
        }


        // Find a user by their email
        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            // Find the user in the database based on their email
            return await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Email == email);
        }

        // Find a user by their user ID
        public async Task<ApplicationUser> FindByIdAsync(int userId)
        {
            // Find the user in the database based on their ID
            return await _context.ApplicationUsers.FindAsync(userId);
        }

        // Find a user by their phone number (assuming it is unique)
        public async Task<ApplicationUser> FindByPhoneAsync(string phoneNumber)
        {
            // Find the user in the database based on their phone number
            return await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

        // Remove a user by their user ID
        public async Task RemoveUserAsync(string email)
        {
            // Find the user by their ID
            var user = await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                // Remove the user from the database and save changes
                _context.ApplicationUsers.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

