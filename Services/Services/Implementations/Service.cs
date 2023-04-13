using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Extensions;

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

            if (typeName.EndsWith("ViewModel"))
            {
                typeName = typeName.Substring(0, typeName.Length - 9) + "s";
            }

            return typeName;
        }

        public async Task<IEnumerable<TEntity>> Get<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            var queryString = $"?predicate={predicate}";
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<TEntity>>($"api/myresource{queryString}");

            if (response == null)
            {
                throw new Exception($"Failed to retrieve data.");
            }
            return response;
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TEntity>($"/api/{GetAPIName().ToLower()}/{id}");
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
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _httpClient.PostAsJsonAsync($"/api/{GetAPIName().ToLower()}/range/delete", entities);
        }
    }
}
