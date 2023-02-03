using Microsoft.EntityFrameworkCore;

namespace CapstoneProject_ApiLayer.DataAccessLayer
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=RAMAZANSURUCU; database=DbCapstoneApi; integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
