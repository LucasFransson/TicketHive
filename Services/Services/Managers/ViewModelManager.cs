using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Implementations;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Managers
{
    public abstract class ViewModelManager
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





        public async Task<IEnumerable<EventViewModel>> SortEventsByDateAsync(IEnumerable<EventViewModel> events)
        {
            return await Task.FromResult(events.OrderBy(e => e.StartTime));
        }

        public async Task<IEnumerable<EventViewModel>> SortEventsByPriceAsync(IEnumerable<EventViewModel> events)
        {
            return await Task.FromResult(events.OrderBy(e => e.Price));
        }

        public async Task<IEnumerable<EventViewModel>> SortEventsByNameAsync(IEnumerable<EventViewModel> events)
        {
            return await Task.FromResult(events.OrderBy(e => e.Name));
        }

        public async Task<IEnumerable<EventViewModel>> SortEventsBySoldOutAsync(IEnumerable<EventViewModel> events)
        {
            return await Task.FromResult(events.OrderBy(e => e.IsSoldOut));
        }
        public async Task<IEnumerable<EventViewModel>> GetEventsByCountryAsync(string countryName,UnitOfService uos)
        {
            var country = await GetCountryViewModelByNameAsync(countryName, uos);
            var events = await uos.EventService.GetAllAsync();
            return await Task.FromResult(events.Where(e => e.Country.Name == country.Name));
        }

        public async Task<IEnumerable<EventViewModel>> GetEventsByEventTypeAsync(string eventTypeName,UnitOfService uos)
        {
            var eventType = await GetEventTypeViewModelByNameAsync(eventTypeName,uos);
            var events = await uos.EventService.GetAllAsync();
            return await Task.FromResult(events.Where(e => e.EventType.Name == eventType.Name));
        }
        public async Task<IEnumerable<EventViewModel>> FilterEventsByDateRangeAsync(IEnumerable<EventViewModel> events, DateTime startDate, DateTime endDate)
        {
            return await Task.FromResult(events.Where(e => e.StartTime >= startDate && e.EndTime <= endDate));
        }
        public async Task<CountryViewModel> GetCountryViewModelByNameAsync(string name,UnitOfService uos)
        {
            var countries = await uos.CountryService.GetAllAsync();
            return await Task.FromResult(countries.FirstOrDefault(c => c.Name == name));
        }

        public async Task<EventTypeViewModel> GetEventTypeViewModelByNameAsync(string name,UnitOfService uos)
        {
            var eventTypes = await uos.EventTypeService.GetAllAsync();
            return await Task.FromResult(eventTypes.FirstOrDefault(et => et.Name == name));
        }
        public async Task<IEnumerable<TicketViewModel>> GetTicketsByEventAsync(EventViewModel eventViewModel,UnitOfService uos)
        {
            var events = await uos.EventService.GetAllAsync();
            var selectedEvent = events.FirstOrDefault(e => e.Id == eventViewModel.Id);
            if (selectedEvent == null)
            {
                // return null eller error eller något
            }

            var tickets = await uos.TicketService.GetAllAsync();
            return await Task.FromResult(tickets.Where(t => t.Event.Id == selectedEvent.Id));
        }
    }
}
