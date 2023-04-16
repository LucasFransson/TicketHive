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
			//Ensures that the ID is not automatically created and set
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
                               "Music Concerts",
                               events,
                               tickets);

			DataSeeder.AddData(2, "Spain",
				   "El Clásico",
				   "A Football Match between Real Madrid and Barcelona",
				   300,
				   100,
				   new DateTime(2023, 10, 21, 20, 00, 0),
				   new DateTime(2023, 10, 21, 22, 00, 0),
				   "Sports Events",
				   events,
				   tickets);

			DataSeeder.AddData(3, "United Kingdom",
				   "Glastonbury",
				   "A Music Festival featuring top artists",
				   200,
				   150,
				   new DateTime(2023, 06, 23, 10, 00, 0),
				   new DateTime(2023, 06, 25, 23, 59, 59),
				   "Festivals",
				   events,
				   tickets);

			DataSeeder.AddData(4, "France",
				   "Bordeaux Wine Tasting",
				   "A Wine Tasting event featuring top Bordeaux wines",
				   50,
				   200,
				   new DateTime(2023, 08, 12, 14, 00, 0),
				   new DateTime(2023, 08, 12, 18, 00, 0),
				   "Food and wine tastings",
				   events,
				   tickets);

			DataSeeder.AddData(5, "Germany",
				   "German Stand-Up Comedy Night",
				   "A Comedy Show featuring top German comedians",
				   100,
				   50,
				   new DateTime(2023, 09, 08, 20, 00, 0),
				   new DateTime(2023, 09, 08, 22, 00, 0),
				   "Comedy shows",
				   events,
				   tickets);

			DataSeeder.AddData(6, "Italy",
				   "Milan Fashion Week",
				   "A Trade Show showcasing top fashion brands",
				   130,
				   500,
				   new DateTime(2023, 10, 16, 09, 00, 0),
				   new DateTime(2023, 10, 20, 18, 00, 0),
				   "Conferences and trade shows",
				   events,
				   tickets);

			DataSeeder.AddData(7, "Austria",
				   "Vienna Philharmonic Orchestra",
				   "A Classical Music Concert by the Vienna Philharmonic Orchestra",
				   100,
				   100,
				   new DateTime(2023, 11, 03, 19, 30, 0),
				   new DateTime(2023, 11, 03, 22, 00, 0),
				   "Music Concerts",
				   events,
				   tickets);

			DataSeeder.AddData(8, "Denmark",
				   "Copenhagen Food Festival",
				   "A Food Festival featuring top chefs and restaurants",
				   200,
				   50,
				   new DateTime(2023, 08, 25, 12, 00, 0),
				   new DateTime(2023, 08, 27, 22, 00, 0),
				   "Festivals",
				   events,
				   tickets);

			DataSeeder.AddData(9, "Ireland",
				   "Ireland vs. England Rugby Match",
				   "A Rugby Match between Ireland and England",
				   250,
				   80,
				   new DateTime(2023, 10, 14, 19, 00, 0),
				   new DateTime(2023, 10, 14, 21, 00, 0),
				   "Sports Events",
				   events,
				   tickets);

			DataSeeder.AddData(10, "Netherlands",
				   "The Phantom of the Opera",
				   "A Musical Theater Show based on the novel by Gaston Leroux",
				   100,
				   120,
				   new DateTime(2023, 09, 10, 14, 30, 0),
				   new DateTime(2023, 09, 10, 17, 00, 0),
				   "Musicals",
				   events,
				   tickets);

			DataSeeder.AddData(11, "Switzerland",
				   "Wine and Cheese Tasting in Geneva",
				   "A Wine and Cheese Tasting event in Geneva",
				   200,
				   80,
				   new DateTime(2023, 07, 01, 18, 00, 0),
				   new DateTime(2023, 07, 01, 20, 00, 0),
				   "Food and wine tastings",
				   events,
				   tickets);

			// Add seed data for EventModel from the list of events
			modelBuilder.Entity<EventModel>().HasData(events);
            // Add seed data for TicketModel from the list of tickets
            modelBuilder.Entity<TicketModel>().HasData(tickets);
        }
    }
}
