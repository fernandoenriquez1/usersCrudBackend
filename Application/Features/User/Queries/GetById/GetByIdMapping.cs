using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetById
{
    public class GetByIdMapping : AutoMapper.Profile
    {
        public GetByIdMapping()
        {
            CreateMap<Domain.User, GetByIdResponse>();
        }
    }
}
