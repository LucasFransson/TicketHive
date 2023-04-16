using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Implementations
{
    public class EventTypeService : Service<EventTypeViewModel>, IEventTypeService
    {  
        //private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClient;
        public EventTypeService(HttpClient httpClient) : base(httpClient)
        {   
            _httpClient = httpClient;
        }
    }
}
