using System.ComponentModel.DataAnnotations;

namespace TicketHive.Server.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public required EventModel Event { get; set; }
        [MaxLength(100)]
        public required string Username { get; set; }
        public required decimal Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
    }
}
