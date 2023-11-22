using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Delete
{
    public class DeleteCommand : IRequest<DeleteResponse>
    {
        public int UserId;
        public DeleteCommand(int userId)
        {
            UserId = userId;
        }
    }
}
