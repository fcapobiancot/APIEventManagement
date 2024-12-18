﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManagement.DTO;
using EventManagement.Model;

namespace EventManagement.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Session
            CreateMap<User, SessionDTO>()
                .ForMember(target => target.RolDescription, opt => opt.Ignore());
            #endregion

            #region Login
            CreateMap<User, LoginDTO>();
            #endregion

            #region User

            CreateMap<User, UserDTO>();

            CreateMap<UserDTO, User>();

            #endregion

        }
    }
}
