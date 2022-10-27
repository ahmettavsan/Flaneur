using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Repository
{
    public class AppDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        //public DbSet<AppUser> AppUsers { get; set; } veri tabanına identity tablelarını tanıtmaya gerek yok
        public DbSet<Place> Places { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<BasketTicket> BasketTickets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
