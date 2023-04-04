using System.ComponentModel.DataAnnotations;

namespace TicketHive.Server.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public EventModel Event { get; set; }
        [MaxLength(100)]
        public required string Username { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
