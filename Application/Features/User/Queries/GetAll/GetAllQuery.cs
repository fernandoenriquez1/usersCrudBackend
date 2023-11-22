using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetAll
{
    public class GetAllQuery : IRequest<GetAllResponse>
    {
        public string? Search { get; set; }
        public DateTime StartCreatedDate { get; set; }
        public DateTime EndCreatedDate { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        public GetAllQuery(string? search, DateTime startCreatedDate, DateTime endCreatedDate, int page, int limit)
        {
            Search = search;
            StartCreatedDate = startCreatedDate;
            EndCreatedDate = endCreatedDate;
            Page = page;
            Limit = limit;
        }
    }
}
