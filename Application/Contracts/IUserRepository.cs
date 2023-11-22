using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllPaginated(string? search, DateTime startCreatedDate, DateTime endCreatedDate);
    }
}
