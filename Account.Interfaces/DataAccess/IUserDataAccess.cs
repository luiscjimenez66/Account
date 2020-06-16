using Account.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Interfaces.DataAccess
{
    public interface IUserDataAccess
    {
        Task<User> Save(User user);

        Task Update(User user);

        Task<User> Get(int userId);

        Task<User> Get(string UserName);

        Task<User> LogIn(string user, string Password);
    }
}
