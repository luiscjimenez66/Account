using Account.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Interfaces.Business.Validations
{
    public interface IPersonValidate
    {
        bool ValidateExistPerson(InPersonCreateDTO personDTO, bool returnException = true);
    }
}
