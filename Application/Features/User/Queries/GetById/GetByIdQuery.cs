using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdResponse>
    {
        public int UserId { get; set; }

        public GetByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
