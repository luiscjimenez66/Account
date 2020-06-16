using Account.Entities;
using Account.InfrastructureEF;
using Account.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.DataAccessLayer
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly ApplicationDbContext _context;

        public UserDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Get(int userId)
        {
            return await _context.Users
                            .Include(_ => _.Person)
                            .FirstOrDefaultAsync(_ => _.UserId == userId);
        }

        public async Task<User> Get(string UserName)
        {
            return await _context.Users
                        .FirstOrDefaultAsync(_ => _.UserName == UserName);
        }

        public async Task<User> LogIn(string UserName, string Password)
        {
            return await _context.Users
                        .FirstOrDefaultAsync(_ => _.UserName == UserName && _.Password == Password);
        }

        public async Task<User> Save(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
