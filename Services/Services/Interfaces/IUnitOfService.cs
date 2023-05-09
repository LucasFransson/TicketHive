using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Interfaces
{
    public interface IUnitOfService 
    {

        ITicketService TicketService { get; }
        ICountryService CountryService { get; }
        IEventTypeService EventTypeService { get; }
        IEventService EventService { get; }
        ISoldTicketService SoldTicketService { get; } 
		IService<UserViewModel> UserService { get; }
        
	}
}
