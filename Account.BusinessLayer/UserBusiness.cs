using Account.BusinessLayer.Exception;
using Account.DTO;
using Account.DTO.Output;
using Account.Entities;
using Account.Interfaces.Business;
using Account.Interfaces.Business.Validations;
using Account.Interfaces.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Account.BusinessLayer.Configuration;

namespace Account.BusinessLayer
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDataAccess _userData;
        private readonly IUserValidation _userValidate;
        private readonly IPersonValidate _personValidate;
        private readonly IUserBalanceDataAccess _userBalance;
        private readonly IMapper _mapper;

        public UserBusiness(
                            IUserDataAccess userData, 
                            IUserValidation userValidate, 
                            IPersonValidate personValidate,
                            IUserBalanceDataAccess userBalance,
                            IMapper mapper)
        {
            _userData = userData;
            _userValidate = userValidate;
            _personValidate = personValidate;
            _userBalance = userBalance;
            _mapper = mapper;
        }

        public async Task<OutUserDTO> Get(int userId)
        {
            var user = await _userData.Get(userId);

            if(user == null) 
            {
                throw new BusinessException("The user was not found.", StatusCodes.Status400BadRequest);
            }

            return BuildUserDTO(user);
        }

        public async Task<OutUserDTO> Save(InUserCreateDTO userDTO)
        {
            _personValidate.ValidateExistPerson(userDTO.Person);

            _userValidate.ValidateExistUser(userDTO);

            var user = BuildUser(userDTO);

            var userBalance = new UserBalance()
            {
                UserId = user.UserId,
                Principal = true,
                PermissionAdmin = true,
                Balance = new Balance()
                {
                    CurrencyId = (int)eCurrencies.EURO,
                    StatusId = (int)eStatuses.ACTIVE,
                    Amount = 0,
                    CreatedAt = DateTime.UtcNow
                },
                User = user
            };

            await _userBalance.Save(userBalance);
            
            return BuildUserDTO(userBalance.User);
        }

        #region Mapping

        private User BuildUser(InUserCreateDTO userDTO) 
        {
            User user = _mapper.Map<User>(userDTO);
            user.StatusId = (int)eStatuses.ACTIVE;
            user.CreatedAt = DateTime.UtcNow;
            user.Person.StatusId = (int)eStatuses.ACTIVE;

            return user;
        }

        private OutUserDTO BuildUserDTO(User user)
        {
            return _mapper.Map<OutUserDTO>(user);
        }

        #endregion


    }
}
