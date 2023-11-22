using Application.Features.User.Queries.GetAll;
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
    }
}
