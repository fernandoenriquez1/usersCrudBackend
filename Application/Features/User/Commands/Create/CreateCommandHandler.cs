using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, CreateResponse>
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public CreateCommandHandler(IMediator mediator, IMapper mapper, IUserRepository userRepository)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<CreateResponse> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            //validar que no exista un usuario con el mismo correo
            var userFindByEmail = await userRepository.GetFirstOrDefaultAsync(x => x.Email == request.Email);

            if (userFindByEmail != null)
            {
                throw new ApplicationException("Ya existe un usuario con el mismo correo");
            }

            var user = mapper.Map<Domain.User>(request);
            try
            {
                user = await userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {

            }

            return mapper.Map<CreateResponse>(user);
        }
    }
}
