using Data_Access_Layer.Data_Context;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<User> GetUserByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<IEnumerable<User>> GetAllUsersWithoutPasswords()
        {
            var usersWithoutPasswords = await _context.Users
                .Select(user => new User
                {
                    UserName = user.UserName,
                    Name= user.UserName,
                })
                .ToListAsync();

            return usersWithoutPasswords;
        }
        public User Update(User user)
        {
            _context.Users.Update(user);
            return user;
        }
    }
}
