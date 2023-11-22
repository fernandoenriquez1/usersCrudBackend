using Application.Features.User.Commands.Create;
using Application.Features.User.Queries.GetAll;
using Application.Features.User.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("Search", Name = "GetAllUsers")]
        [ProducesResponseType(typeof(IEnumerable<GetAllResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(
                                                string? search,
                                                DateTime startCreatedDate,
                                                DateTime endCreatedDate,
                                                int page = 1,
                                                int limit = 100)
        {
            var response = await mediator.Send(new GetAllQuery(search, startCreatedDate, endCreatedDate, page, limit));
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(GetByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await mediator.Send(new GetByIdQuery(id));
            return Ok(response);
        }


        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
