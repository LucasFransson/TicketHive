namespace TicketHive.Server.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public int MaxUsers { get; set; }
        public bool isSoldOut { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        List<ApplicationUser> Users { get; set; }
    }
}
