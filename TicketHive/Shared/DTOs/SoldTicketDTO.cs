using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Shared.DTOs
{
    public class SoldTicketDTO
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Username { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        // Constructor for DTO from Model Input Parameters
        public SoldTicketDTO(int id, int eventId,  string username, decimal price, DateTime startTime, DateTime endTime)
        {
            Id = id;
            EventId = eventId;
            Username = username;
            Price = price;
            StartTime = startTime;
            EndTime = endTime;
        }



    }
}