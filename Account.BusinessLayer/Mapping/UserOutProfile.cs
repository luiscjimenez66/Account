using Account.DTO.Output;
using Account.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.BusinessLayer.Mapping
{
    public class UserOutProfile : Profile
    {
        public UserOutProfile()
        {
            CreateMap<User, OutUserDTO>();
        }
    }
}
