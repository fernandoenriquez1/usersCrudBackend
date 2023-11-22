using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, UpdateResponse>
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UpdateCommandHandler(IMediator mediator, IMapper mapper, IUserRepository userRepository)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<UpdateResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            //buscar al usuario por id
            var usuario = await userRepository.GetFirstOrDefaultAsync(x => x.UserId == request.UserId);

            // validamos que el usuario exista
            if (usuario == null)
            {
                throw new ApplicationException("No se encuentra al usuario");
            }

            //validar que no exista un usuario con el mismo correo
            var userFindByEmail = await userRepository.GetFirstOrDefaultAsync(x => x.Email == request.Email && x.UserId != request.UserId);

            if (userFindByEmail != null)
            {
                throw new ApplicationException("Ya existe un usuario con el mismo correo");
            }

            var user = mapper.Map<Domain.User>(request);
            user = await userRepository.UpdateAsync(user);

            return mapper.Map<UpdateResponse>(user);
        }
    }
}
