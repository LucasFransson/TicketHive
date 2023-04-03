using System.ComponentModel.DataAnnotations;

namespace TicketHive.Server.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int MaxUsers { get; set; }
        public bool IsSoldOut { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        List<UserModel> Users { get; set; } = new();
        public CountryModel Country { get; set; } 
        public EventTypeModel EventType { get; set; }

    }
}
