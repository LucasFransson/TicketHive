﻿using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface ICountryRepository : IRepository<CountryModel>
    {
        Task<List<CountryViewModel>> GetAllAsync();
        Task<CountryViewModel>? GetByName(string name);
    }
}
