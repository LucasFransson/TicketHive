using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Shared.DTOs;
public class TicketDTO
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public EventDTO? Event { get; set; }
    public decimal Price { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    // Constructor for DTO from Model Input Parameters
    public TicketDTO(int id, int eventId, EventDTO eventDto, decimal price, DateTime startTime, DateTime endTime)
    {
        Id = id;
        EventId = eventId;
        Event = eventDto;
        Price = price;
        StartTime = startTime;
        EndTime = endTime;
    }
}
