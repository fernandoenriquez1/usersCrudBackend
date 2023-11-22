﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetAll
{
    public class GetAllMapping : AutoMapper.Profile
    {
        public GetAllMapping()
        {
            CreateMap<Domain.User, User>();
        }
    }
}
