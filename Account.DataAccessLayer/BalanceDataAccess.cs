using Account.Entities;
using Account.InfrastructureEF;
using Account.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.DataAccessLayer
{
    public class BalanceDataAccess : IBalanceDataAccess
    {
        private readonly ApplicationDbContext _context;

        public BalanceDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Balance> Save(Balance balance)
        {
            _context.Balances.Add(balance);
            await _context.SaveChangesAsync();

            return balance;
        }
    }
}
