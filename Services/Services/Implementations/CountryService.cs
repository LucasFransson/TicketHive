using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Implementations
{
    public class CountryService : Service<CountryViewModel>, ICountryService
    {
        //private readonly HttpClient _httpClient;
        //private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient) : base(httpClient)
        {
            //_httpClient = httpClient;
        }

  //      public async Task<CountryViewModel?> GetByNameAsync(string name)
  //      {
		//	return await _httpClient.GetFromJsonAsync<CountryViewModel>($"/api/countries/{name}");
		//}
	}
}
