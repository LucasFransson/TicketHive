using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Models
{
    public class EventTypeModel
    {
        [Key]
        [MaxLength(50)]
        public required string Name { get; set; }

        public EventTypeModel()
        {
            
        }

        // Constructor for Model from recieving DTO
        [SetsRequiredMembers]
        public EventTypeModel(EventTypeDTO dto) 
        {
            Name = dto.Name;
        }
    }
}
