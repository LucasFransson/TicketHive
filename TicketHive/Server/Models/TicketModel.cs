using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketHive.Server.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public required int EventId { get; set; }
        public EventModel? Event { get; set; }
        [MaxLength(100)]
        public string? Username { get; set; }
        public required decimal Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
    }
}
