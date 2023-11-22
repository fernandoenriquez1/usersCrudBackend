using Application.Contracts;
using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserCrudDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllPaginated(string? search, DateTime startCreatedDate, DateTime endCreatedDate)
        {
            var list = await _context.User.Where(
                        x =>
                        (
                            search == null
                            ||
                            ((x.Name != null ? x.Name : "") + " " + (x.PaternalSurname != null ? x.PaternalSurname : "") + " " + (x.MaternalSurname != null ? x.MaternalSurname : "")).ToLower().Contains(search.ToLower())
                            ||
                            (x.CellphoneNumber != null && x.CellphoneNumber.Contains(search.ToLower()))
                            ||
                            (x.Email != null && x.Email.Contains(search.ToLower()))
                        )
                        //&&
                        //x.CreatedAt >= startCreatedDate && x.CreatedAt <= endCreatedDate
                    ).ToListAsync();

            return list;
        }
    }
}
