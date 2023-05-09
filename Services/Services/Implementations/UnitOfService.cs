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
    public class UnitOfService : IUnitOfService
    {
        private readonly HttpClient _httpClient;

        public ITicketService TicketService { get; set; }

        public ICountryService CountryService { get; set; }

        public IEventTypeService EventTypeService { get; set; }

        public IEventService EventService { get; set;
        } 
        public ISoldTicketService SoldTicketService { get; set; }
		public IService<UserViewModel> UserService { get; set; }
       

		public UnitOfService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            TicketService = new TicketService(_httpClient); 
            CountryService = new CountryService(_httpClient);
            EventTypeService = new EventTypeService(_httpClient);
            EventService = new EventService(_httpClient);
			UserService = new UserService(_httpClient);
            SoldTicketService = new SoldTicketService(_httpClient);
		}
    }
}
