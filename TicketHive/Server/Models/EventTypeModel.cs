using System.ComponentModel.DataAnnotations;

namespace TicketHive.Server.Models
{
    public class EventTypeModel
    {
        [Key]
        [MaxLength(50)]
        public required string Name { get; set; }
        public List<EventModel>? Events { get; set; }
    }
}
