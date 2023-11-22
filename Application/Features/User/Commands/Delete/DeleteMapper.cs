using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Delete
{
    public class DeleteMapper : Profile
    {
        public DeleteMapper()
        {
            CreateMap<DeleteCommand, Domain.User>();
            CreateMap<Domain.User, DeleteResponse>();
        }
    }
}
