﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.ViewModels;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;

namespace TicketHive.Bll.Services.Implementations
{
    public class TicketService : Service<TicketViewModel>, ITicketService
    {
        private readonly HttpClient _httpClient;
        public TicketService(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TicketViewModel>> GetTickets(int id, int quantity)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TicketViewModel>>($"/api/tickets/{id}/{quantity}");
        }
    }
}
