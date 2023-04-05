using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.ViewModels
{
    public class EventTypeViewModel
    {
        [Key]
        [MaxLength(50)]
        public required string Name { get; set; }
        public List<EventViewModel>? Events { get; set; } = new();
    }
}
