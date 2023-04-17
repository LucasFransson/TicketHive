using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public required int EventId { get; set; }
        public EventModel? Event { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public required decimal Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }

        public TicketModel()
        {
        }

        // Constructor for Model from recieving DTO
        [SetsRequiredMembers]
        public TicketModel(TicketDTO dto)
        {
            Id = dto.Id;
            EventId = dto.EventId;
            Event = new EventModel(dto.Event);
            Price = dto.Price;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
        }
    }
}
