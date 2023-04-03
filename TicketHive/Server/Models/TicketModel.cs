namespace TicketHive.Server.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public EventModel Event { get; set; }
        public UserModel User { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
