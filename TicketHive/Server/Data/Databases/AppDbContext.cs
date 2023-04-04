using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<CountryModel> Countries;
        public DbSet<EventModel> Events;
        public DbSet<EventTypeModel> EventTypes;
        public DbSet<TicketModel> Tickets;
    }
}
