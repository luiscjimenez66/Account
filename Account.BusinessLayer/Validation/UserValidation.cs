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
    public class UserValidation : IUserValidation
    {
        private readonly IUserDataAccess _userDA;

        public UserValidation(IUserDataAccess userDA)
        {
            _userDA = userDA;
        }

        public bool ValidateExistUser(InUserCreateDTO userDTO, bool returnException = true) 
        {
            var user = _userDA.Get(userDTO.UserName);

            if (returnException && user.Result != null)
            {
                throw new BusinessException("The user is already registered.", StatusCodes.Status400BadRequest);
            }

            return user.Result != null;
        }
    }
}
