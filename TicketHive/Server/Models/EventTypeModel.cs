using System.ComponentModel.DataAnnotations;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Models
{
    public class EventTypeModel
    {
        [Key]
        [MaxLength(50)]
        public required string Name { get; set; }
        //public List<EventModel>? Events { get; set; }


        public EventTypeModel()
        {
            
        }
        public EventTypeModel(EventTypeDTO eDto) // Constructor for DTO
        {
            Name = eDto.Name;
            //Events = eDto.Events;
        }
    }
}
