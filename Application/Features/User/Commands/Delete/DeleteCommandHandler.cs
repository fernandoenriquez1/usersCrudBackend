using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, DeleteResponse>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public DeleteCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<DeleteResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new ApplicationException("No se encontró al usuario");
            }

            user = await this.userRepository.SoftDeleteAsync(user!);

            var response = mapper.Map<DeleteResponse>(user);

            return response;
        }
    }
}
