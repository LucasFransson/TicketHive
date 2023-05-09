using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Implementations
{
    public class SoldTicketService : Service<SoldTicketViewModel>, ISoldTicketService
    {
        private readonly HttpClient _httpClient;
        public SoldTicketService(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<SoldTicketViewModel>> GetAllByNameAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SoldTicketViewModel>>($"/api/soldtickets/usertickets/{name}");
        }
    }
}