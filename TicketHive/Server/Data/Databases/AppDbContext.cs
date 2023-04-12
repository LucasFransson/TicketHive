using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Models;
using TicketHive.Server.StaticMethods;

namespace TicketHive.Server.Data.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()   // Empty constructor for enabling access to unit of work from Models(for model ctor(dto))
        {
            
        }
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
            // Ensures that the ID is not automatically created and set
            modelBuilder.Entity<SoldTicketModel>()
                .Property(t => t.Id)
                .ValueGeneratedNever();

            // Add seed data for CountryModel
            modelBuilder.Entity<CountryModel>().HasData(DataSeeder.Countries);

            // Add seed data for EventTypeModel
            modelBuilder.Entity<EventTypeModel>().HasData(DataSeeder.EventTypes);

            // Create Lists for Events and Tickets
            var events = new List<EventModel>();
            var tickets = new List<TicketModel>();

            // Create and add seed data for an Event and Tickets ( adding the events/tickets to their lists )
            DataSeeder.AddData(1,"Sweden",
                               "Slayer",
                               "A Heavy Metal Concert",
                               500,
                               300,
                               new DateTime(2023,07,30,19,30,0),
                               new DateTime(2023, 07, 30, 23, 0, 0),
                               "Music",//eventTypes.First(et=>et.Name=="Music"),
                               events,
                               tickets);

            // Add seed data for EventModel from the list of events
            modelBuilder.Entity<EventModel>().HasData(events);
            // Add seed data for TicketModel from the list of tickets
            modelBuilder.Entity<TicketModel>().HasData(tickets);
        }
    }
}
