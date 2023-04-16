using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Implementations
{
    public class EventService : Service<EventViewModel>, IEventService
    {
        //private readonly HttpClient _httpClient;
        //private readonly HttpClient _httpClient;
        public EventService(HttpClient httpClient) : base(httpClient)
        {
            //_httpClient = httpClient;
        }
    }
}
