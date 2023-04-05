using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.ViewModels
{
    public class EventViewModel
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
        public List<TicketViewModel> SoldTickets { get; set; } = new();
        public required CountryViewModel Country { get; set; }
        public required EventTypeViewModel EventType { get; set; }
    }
}
