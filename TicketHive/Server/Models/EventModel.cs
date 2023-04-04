using System.ComponentModel.DataAnnotations;

namespace TicketHive.Server.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public required int MaxUsers { get; set; }
        public bool IsSoldOut { get; set; }    // Consider Changing to Expression ( MaxUser & SoldTickets ) 
        public required decimal Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public List<TicketModel> SoldTickets { get; set; } = new();
        public required CountryModel Country { get; set; }
        public required EventTypeModel EventType { get; set; }
    }
}
