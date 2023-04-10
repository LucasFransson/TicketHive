using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketHive.Server.Models
{
    public class SoldTicketModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public EventModel? Event { get; set; }

        [MaxLength(100)]
        public required string Username { get; set; }
        public required decimal Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
    }
}
