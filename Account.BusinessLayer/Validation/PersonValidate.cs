using Account.BusinessLayer.Exception;
using Account.DTO;
using Account.Interfaces.Business.Validations;
using Account.Interfaces.DataAccess;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.BusinessLayer.Validation
{
    public class PersonValidate : IPersonValidate
    {
        private readonly IPersonDataAccess _personDA;

        public PersonValidate(IPersonDataAccess personDA)
        {
            _personDA = personDA;
        }

        public bool ValidateExistPerson(InPersonCreateDTO personDTO, bool returnException = true)
        {
            var person = _personDA.Get(personDTO.IdentificationTypeId, personDTO.IdentificationNumber);

            if (returnException && person.Result != null)
            {
                throw new BusinessException("The person is already registered.", StatusCodes.Status400BadRequest);
            }

            return person.Result != null;
        }
    }
}
