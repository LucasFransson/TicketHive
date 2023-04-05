using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public EventViewModel Event { get; set; }
        public string Username { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //public TicketViewModel()
        //{
            
        //}
    }
}
