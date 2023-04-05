using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.ViewModels
{
    public class EventTypeViewModel
    {
        public string Name { get; set; }
        public List<EventViewModel>? Events { get; set; } = new();
    }
}
