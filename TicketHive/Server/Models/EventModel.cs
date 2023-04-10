using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool IsSoldOut => (MaxUsers <= SoldTickets?.Count) ? true : false; 
        public required decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<TicketModel>? SoldTickets { get; set; }

        [ForeignKey(nameof(Country))]
        public required string CountryName { get; set; }
        public CountryModel? Country { get; set; }
        [ForeignKey(nameof(EventType))]
        public required string EventTypeName { get; set; }
        public EventTypeModel? EventType { get; set; }

    }
}
