using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.DTOs;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Implementations
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly HttpClient _httpClient;


        public Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method for string manipulation of ViewModel to fit the API controllers Route
        public string GetAPIName()
        {
            string typeName = typeof(TEntity).Name;

            if(typeName=="CountryViewModel") // Check for CountryViewModel because the generic method spells it wrong, to "countrys"
            {
                return "countries";
            }
            else if (typeName.EndsWith("ViewModel"))
            {
                typeName = typeName.Substring(0, typeName.Length - 9) + "s";
            }

            return typeName;
        }
  
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TEntity>($"/api/{GetAPIName().ToLower()}/{id}");
        }
		public async Task<TEntity> GetByNameAsync(string name)
		{
			return await _httpClient.GetFromJsonAsync<TEntity>($"/api/{GetAPIName().ToLower()}/{name}");
		}
        public async Task<IEnumerable<TEntity>> GetAllByNameAsync(string name)
        {
            if (typeof(TEntity) == typeof(SoldTicketViewModel)) // This should be put in the specific service instead
            {
                // Call the UserTickets endpoint instead of the default generic endpoint
                return await _httpClient.GetFromJsonAsync<IEnumerable<TEntity>>($"/api/{GetAPIName().ToLower()}/usertickets/{name}");
            }

            return await _httpClient.GetFromJsonAsync<IEnumerable<TEntity>>($"/api/{GetAPIName().ToLower()}/{name}");
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TEntity>>($"/api/{GetAPIName().ToLower()}");
        }
        public async Task AddAsync(TEntity entity)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/{GetAPIName().ToLower()}", entity);
            response.EnsureSuccessStatusCode();
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/{GetAPIName().ToLower()}/range", entities);
            response.EnsureSuccessStatusCode();
        }
        public void Remove(TEntity entity)
        {
            _httpClient.DeleteAsync($"/api/{GetAPIName().ToLower()}/{entity}");
        }
        public void Remove(int id)
        {
            _httpClient.DeleteAsync($"/api/{GetAPIName().ToLower()}/{id}");
        }
        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/{GetAPIName().ToLower()}/range/delete", entities);
            response.EnsureSuccessStatusCode();
        }
	}
}
