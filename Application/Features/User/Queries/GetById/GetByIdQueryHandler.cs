using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IUserRepository personRepository, IMapper mapper)
        {
            userRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetByIdAsync(request.UserId);

            // validamos que el usuario exista
            if (user == null)
            {
                throw new ApplicationException("No se encuentra al usuario");
            }

            var response = this._mapper.Map<GetByIdResponse>(user);

            return response;
        }
    }
}
