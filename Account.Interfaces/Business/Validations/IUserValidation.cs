using Account.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Interfaces.Business.Validations
{
    public interface IUserValidation
    {
        bool ValidateExistUser(InUserCreateDTO userDTO, bool returnException = true);
    }
}
