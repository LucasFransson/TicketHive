using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Bll.Services.Managers;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Implementations
{
    public class UnitOfService : ViewModelManager, IUnitOfService
    {
        private readonly HttpClient _httpClient;

        public IService<TicketViewModel> TicketService {get;}

        public IService<CountryViewModel> CountryService { get; }

        public IService<EventTypeViewModel> EventTypeService { get; }

        public IService<EventViewModel> EventService { get; }

        public UnitOfService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            TicketService = new TicketService(_httpClient); 
            CountryService = new CountryService(_httpClient);
            EventTypeService = new EventTypeService(_httpClient);
            EventService = new EventService(_httpClient);
        }
    }
}
