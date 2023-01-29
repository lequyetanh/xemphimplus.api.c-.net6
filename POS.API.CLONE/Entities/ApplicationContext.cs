using Microsoft.EntityFrameworkCore;

namespace POS.API.CLONE.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public virtual DbSet<Admin_User> Admin_User { set; get; }
        public virtual DbSet<Category_Province> Category_Province { set; get; }
        public virtual DbSet<Country> Country { set; get; }
        public virtual DbSet<User_Entity> User_Object { set; get; }
        public virtual DbSet<Movie> Movie { set; get; }
    }
}
