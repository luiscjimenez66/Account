using Account.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Interfaces.DataAccess
{
    public interface IPersonDataAccess
    {
        Task<Person> Get(int personId);

        Task<Person> Get(int identificationId, string identificationNumber);

        Task<Person> Save(Person person);

        Task Update(Person person);
    }
}
