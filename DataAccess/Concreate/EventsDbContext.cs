using DataAccess.Extentions.EfSeedData;
using Entities.Concreate;
using Entitites.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class EventsDbContext:IdentityDbContext<User,UserRole ,string>
    {
        public EventsDbContext()
        {

        }
        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) 
        {
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Events;Trusted_Connection=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.SeedCity();
            modelBuilder.SeedCategory();
            //modelBuilder.SeedEvent();
            modelBuilder.SeedUser();

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}
