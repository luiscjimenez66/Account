using Account.DTO;
using Account.DTO.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Interfaces.Business
{
    public interface IUserBusiness
    {
        Task<OutUserDTO> Save(InUserCreateDTO userDTO);

        Task<OutUserDTO> Get(int userId);
    }
}
