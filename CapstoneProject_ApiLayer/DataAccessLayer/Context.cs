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
            //optionsBuilder.UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019; database=DbCapstoneApi;user=AdminCapstoneApiDB;password=0y02v6@bD");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Electric> Electrics { get; set; }
    
      
    }
}
