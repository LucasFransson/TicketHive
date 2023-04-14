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
        IService<TicketViewModel> TicketService { get; }
        IService<CountryViewModel> CountryService { get; }
        IService<EventTypeViewModel> EventTypeService { get; }
        IService<EventViewModel> EventService { get; }
		IService<UserViewModel> UserService { get; }

	}
}
