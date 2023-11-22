using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UserCrudDbContextSeed
    {
        public static IEnumerable<User> GetPresetUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "Luis Eduardo",
                    PaternalSurname =  "Silva",
                    MaternalSurname = "Camacho",
                    BirthDate = DateTime.Parse("1995-08-10"),
                    CellphonePrefix = "+52",
                    CellphoneNumber = "311 125 4488",
                    Email = "luis@mail.com"
                },
                new User
                {
                    UserId = 2,
                    Name = "Joel",
                    PaternalSurname =  "Ramirez",
                    MaternalSurname = "Torres",
                    BirthDate = DateTime.Parse("1995-05-10"),
                    CellphonePrefix = "+52",
                    CellphoneNumber = "323 125 4488",
                    Email = "joel@mail.com"
                },
                new User
                {
                    UserId = 3,
                    Name = "Ximena",
                    PaternalSurname =  "Rios",
                    MaternalSurname = "Perez",
                    BirthDate = DateTime.Parse("1994-05-10"),
                    CellphonePrefix = "+52",
                    CellphoneNumber = "311 178 4488",
                    Email = "ximena@mail.com"
                }
            };
        }
    }
}
