using Account.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Interfaces.DataAccess
{
    public interface IBalanceDataAccess
    {
        Task<Balance> Save(Balance balance);
    }
}
