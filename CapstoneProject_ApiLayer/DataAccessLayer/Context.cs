using CapstoneProject_ApiLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public DbSet<User> Users { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
    
      
    }
}
