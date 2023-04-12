﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.DTOs;
using TicketHive.Shared.ViewModels;


namespace TicketHive.Shared.DTO;

public class SoldTicketViewModel
{
    public int Id { get; set; }
    public int EventID { get; set; }
    public EventViewModel? Event { get; set; }
    public string Username { get; set; } 
    public decimal Price { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public SoldTicketViewModel()
    {

    }
    // Constructor for ViewModel from DTO
    public SoldTicketViewModel(SoldTicketDTO dto)
    {
        Id = dto.Id;
        EventID = dto.EventId;
        Event = new EventViewModel(dto.Event);
        Username = dto.Username;
        Price = dto.Price;
        StartTime = dto.StartTime;
        EndTime = dto.EndTime;   
    }
}


