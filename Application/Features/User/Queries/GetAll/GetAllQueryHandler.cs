using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, GetAllResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IUserRepository personRepository, IMapper mapper)
        {
            userRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            int skip = (request.Page - 1) * request.Limit;
            int take = request.Limit;
            var userList = await userRepository.GetAllPaginated(request.Search, request.StartCreatedDate, request.EndCreatedDate);

            var response = new GetAllResponse();
            response.PaginationInfo = new Models.PaginationModel();
            response.PaginationInfo.TotalItems = userList.Count;
            response.PaginationInfo.ItemCount = userList.Count;
            response.PaginationInfo.ItemsPerPage = request.Limit;
            response.PaginationInfo.TotalPages = response.PaginationInfo.TotalItems / request.Limit + 1;
            response.PaginationInfo.CurrentPage = request.Page;
            response.Registros = _mapper.Map<List<User>>(userList.Skip(skip).Take(take));

            return response;
        }
    }
}
