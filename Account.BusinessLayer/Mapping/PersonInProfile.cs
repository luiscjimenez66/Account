using Account.DTO;
using Account.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.BusinessLayer.Mapping
{
    public class PersonInProfile : Profile
    {
        public PersonInProfile()
        {
            CreateMap<InPersonCreateDTO, Person>();
        }
    }
}
