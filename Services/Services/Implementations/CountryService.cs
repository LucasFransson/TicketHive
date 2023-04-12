using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Implementations
{
    public class CountryService : Service<CountryViewModel>, ICountryService
    {
        private readonly HttpClient _httpClient;
        public CountryService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
