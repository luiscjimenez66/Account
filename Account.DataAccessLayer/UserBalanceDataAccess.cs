using Account.Entities;
using Account.InfrastructureEF;
using Account.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.DataAccessLayer
{
    public class UserBalanceDataAccess : IUserBalanceDataAccess
    {
        private readonly ApplicationDbContext _context;

        public UserBalanceDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save(UserBalance userBalance)
        {
            _context.UsersBalances.Add(userBalance);

            await _context.SaveChangesAsync();
        }
    }
}
