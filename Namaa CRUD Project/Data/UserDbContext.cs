using Microsoft.EntityFrameworkCore;
using Namaa_CRUD_Project.Models;

namespace Namaa_CRUD_Project.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<Users_Model> usersModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users_Model>().ToTable("users");
        }
    }
}
