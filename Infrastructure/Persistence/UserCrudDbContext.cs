using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UserCrudDbContext: DbContext
    {
        public UserCrudDbContext(DbContextOptions<UserCrudDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("User_pk");
                entity.Property(e => e.UserId).UseIdentityColumn(1, 1);
                entity.Property(e => e.Name).HasMaxLength(120);
                entity.Property(e => e.PaternalSurname).HasMaxLength(120);
                entity.Property(e => e.MaternalSurname).HasMaxLength(120);
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.CellphonePrefix).HasMaxLength(10);
                entity.Property(e => e.CellphoneNumber).HasMaxLength(15);
                entity.Property(e => e.Email).HasMaxLength(120);
            });

            modelBuilder.Entity<User>().HasData(UserCrudDbContextSeed.GetPresetUsers());
        }

        public DbSet<User>? User { get; set; }
    }
}
