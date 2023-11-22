using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetById
{
    public class GetByIdResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PaternalSurname { get; set; } = string.Empty;
        public string? MaternalSurname { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }

        public string? Address { get; set; } = string.Empty;

        public string CellphonePrefix { get; set; } = string.Empty;
        public string CellphoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
