using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Implementations;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Managers
{
    public class ViewModelManager
    {
        public TicketViewModel CreateTicket()
        {
            return new TicketViewModel();
        }
        public EventTypeViewModel CreateEventType(string eventName)
        {
            return new EventTypeViewModel(eventName);
        }
        public EventViewModel CreateEvent(string eventName,int maxUsers,decimal price,CountryViewModel country)
        {
            return new EventViewModel(eventName,maxUsers,price,country);
        }
        public CountryViewModel CreateCountry(string name, string currency, bool isAvailableForUsers)
        {
            return new CountryViewModel(name, currency, isAvailableForUsers); 
        }


    }
}
