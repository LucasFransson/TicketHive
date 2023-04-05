using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<CountryModel> Countries { get; set; } 
        public DbSet<EventModel> Events { get; set; }
        public DbSet<EventTypeModel> EventTypes { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<SoldTicketModel> SoldTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoldTicketModel>()
                .Property(t => t.Id)
                .ValueGeneratedNever();
        }
    }
}
