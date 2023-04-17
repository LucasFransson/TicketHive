using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketHive.Shared.DTOs;
using TicketHive.Server.Data.Repositories.Implementations;
using TicketHive.Server.Data.Databases;
using TicketHive.Shared.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace TicketHive.Server.Models
{
    [Serializable]
    public class SoldTicketModel
    {
        public int Id { get; set; }
        public required int EventId { get; set; }
        public required string Username { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public required decimal Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }

        public SoldTicketModel()
        {
            
        }
        // Constructor for Model from recieving DTO
        [SetsRequiredMembers]
        public SoldTicketModel(SoldTicketDTO dto)
        {
            Id = dto.Id;
            EventId = dto.EventId;
            Username = dto.Username;
            Price = dto.Price;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
        }

    }
}
