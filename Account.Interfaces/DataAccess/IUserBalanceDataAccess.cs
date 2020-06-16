using Account.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Interfaces.DataAccess
{
    public interface IUserBalanceDataAccess
    {
        Task Save(UserBalance userBalance);
    }
}
