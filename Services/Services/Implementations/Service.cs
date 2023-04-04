using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Extensions;

namespace TicketHive.Bll.Services.Implementations
{
    public class Service<TEntity> : IService<TEntity> 
    {
        private readonly HttpClient _httpClient;

        public Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TEntity> GetByIdAsyncAPINameTest(int id)
        {
            return await _httpClient.GetFromJsonAsync<TEntity>($"/api/{typeof(TEntity).GetAPIName().ToLower()}/{id}");
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TEntity>($"/api/{typeof(TEntity).GetAPIName().ToLower()}/{id}");
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TEntity>>($"/api/{typeof(TEntity).GetAPIName().ToLower()}");
        }
        public async Task AddAsync(TEntity entity)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/{typeof(TEntity).GetAPIName().ToLower()}", entity);
            response.EnsureSuccessStatusCode();
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/{typeof(TEntity).GetAPIName().ToLower()}/range", entities);
            response.EnsureSuccessStatusCode();
        }
        public void Remove(TEntity entity)
        {
            _httpClient.DeleteAsync($"/api/{typeof(TEntity).GetAPIName().ToLower()}/{entity}");
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _httpClient.PostAsJsonAsync($"/api/{typeof(TEntity).GetAPIName().ToLower()}/range/delete", entities);
        }

    }
}
