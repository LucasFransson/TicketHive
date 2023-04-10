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
    public EventViewModel? Event { get; set; }
    public string Username { get; set; }
    public decimal Price { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
