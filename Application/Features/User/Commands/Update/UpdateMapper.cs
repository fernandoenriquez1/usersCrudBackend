using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Update
{
    public class UpdateMapper : Profile
    {
        public UpdateMapper()
        {
            CreateMap<UpdateCommand, Domain.User>();
            CreateMap<Domain.User, UpdateResponse>();
        }
    }
}
