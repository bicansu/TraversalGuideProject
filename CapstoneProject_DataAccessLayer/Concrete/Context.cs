using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=RAMAZANSURUCU; database=DbCapstone; integrated security=true;");
            //optionsBuilder.UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019; database=DbCapstone;user=AdminCapstoneDB;password=Yk@34ir91");
        }
        public DbSet<About> Abouts { get; set; } 
        public DbSet<AccordingtoWeatherHoliday> AccordingtoWeatherHolidays { get;set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<TourInform> TourInforms { get; set; } 
        public DbSet<TravelAgency> TravelAgencys { get; set;}        
        public DbSet<Contact3> Contact3s { get; set; } 
        public DbSet<OurInfo> OurInfos { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MailRequest> MailRequests { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<UserCount> UserCounts { get; set; }
        public DbSet<CompanyEvent> CompanyEvents { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

    }
}
