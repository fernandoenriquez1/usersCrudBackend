using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Create
{
    public class CreateMapper : Profile
    {
        public CreateMapper()
        {
            CreateMap<CreateCommand, Domain.User>();
            CreateMap<Domain.User, CreateResponse>();
        }
    }
}
