using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Shared.DTOs;
public class EventTypeDTO
{
    public string Name { get; set; }
    //public List<EventTypeDTO>? Events { get; set; }   // See ViewModel for info


    public EventTypeDTO()
    {
        
    }
    //Constructor for Model
    public EventTypeDTO(string name)
    {
        Name = name;
    }

    //// Constructor for ViewModel
    //public EventTypeDTO(EventTypeViewModel viewModel)
    //{
    //    Name = viewModel.Name;
    //}
}


