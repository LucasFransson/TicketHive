﻿using System;
using System.Collections.Generic;
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
        //public string EventName { get; set; }
        public EventDTO? Event { get; set; }
        public string Username { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }


}
