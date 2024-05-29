using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=VR; Database=CrasProjectDb; Integrated Security=True; Trusted_Connection=True;Encrypt=false;");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Body> Bodys { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }

    }
}
