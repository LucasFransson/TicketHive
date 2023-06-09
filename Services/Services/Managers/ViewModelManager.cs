﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Implementations;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.ViewModels;



namespace TicketHive.Bll.Services.Managers;

public class ViewModelManager  
{
    // All of the "Create" Methods here should probably be removed, due to changes in design plan
    public  TicketViewModel CreateTicket()
    {
        return new TicketViewModel();
    }
    public  EventTypeViewModel CreateEventType(string eventName)
    {
        return new EventTypeViewModel();
    }
    public  EventViewModel CreateEvent(string eventName,int maxUsers,decimal price,CountryViewModel country)
    {
        return new EventViewModel();
    }
    public  CountryViewModel CreateCountry(string name, string currency, bool isAvailableForUsers)
    {
        return new CountryViewModel(); 
    }

    // Filtration & Sorting Methods
    public  async Task<IEnumerable<EventViewModel>> SortEventsByDateAsync(IEnumerable<EventViewModel> events)
    {
        return await Task.FromResult(events.OrderBy(e => e.StartTime));
    }
    public  async Task<IEnumerable<EventViewModel>> SortEventsByPriceAsync(IEnumerable<EventViewModel> events)
    {
        return await Task.FromResult(events.OrderBy(e => e.Price));
    }
    public async Task<IEnumerable<EventViewModel>> SortEventsByNameAsync(IEnumerable<EventViewModel> events)
    {
        return await Task.FromResult(events.OrderBy(e => e.Name));
    }


    // Unused Sorting/Filtration/Get methods
    public async Task<IEnumerable<EventViewModel>> SortEventsBySoldOutAsync(IEnumerable<EventViewModel> events)
    {
        return await Task.FromResult(events.OrderBy(e => e.IsSoldOut));
    }
    public async Task<IEnumerable<EventViewModel>> GetEventsByCountryAsync(string countryName, UnitOfService uos)
    {
        var country = await GetCountryViewModelByNameAsync(countryName, uos);
        var events = await uos.EventService.GetAllAsync();
        return await Task.FromResult(events.Where(e => e.Country.Name == country.Name));
    }
    public async Task<IEnumerable<EventViewModel>> GetEventsByEventTypeAsync(string eventTypeName, UnitOfService uos)
    {
        var eventType = await GetEventTypeViewModelByNameAsync(eventTypeName, uos);
        var events = await uos.EventService.GetAllAsync();
        return await Task.FromResult(events.Where(e => e.EventType.Name == eventType.Name));
    }
    public async Task<IEnumerable<EventViewModel>> FilterEventsByDateRangeAsync(IEnumerable<EventViewModel> events, DateTime startDate, DateTime endDate)
    {
        return await Task.FromResult(events.Where(e => e.StartTime >= startDate && e.EndTime <= endDate));
    }
    public  async Task<CountryViewModel> GetCountryViewModelByNameAsync(string name,UnitOfService uos)
    {
        var countries = await uos.CountryService.GetAllAsync();
        return await Task.FromResult(countries.FirstOrDefault(c => c.Name == name));
    }

    public async Task<EventTypeViewModel> GetEventTypeViewModelByNameAsync(string name,UnitOfService uos)
    {
        var eventTypes = await uos.EventTypeService.GetAllAsync();
        return await Task.FromResult(eventTypes.FirstOrDefault(et => et.Name == name));
    }
}
