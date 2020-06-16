using Account.DTO.Input;
using Account.DTO.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Interfaces.Business
{
    public interface ISecurityBusiness
    {
        OutAuthenticateDTO Authenticate(InAuthenticateDTO user);
    }
}
