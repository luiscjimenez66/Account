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
    public class PersonDataAccess : IPersonDataAccess
    {
        private readonly ApplicationDbContext _context;

        public PersonDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Person> Get(int personId)
        {
            return _context.People
                        .FirstOrDefaultAsync(_ => _.PersonId == personId);
        }

        public Task<Person> Get(int identificationId, string identificationNumber)
        {
            return _context.People
                        .FirstOrDefaultAsync(_ => _.IdentificationTypeId == identificationId && _.IdentificationNumber == identificationNumber);
        }

        public async Task<Person> Save(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public Task Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
