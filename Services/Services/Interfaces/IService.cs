using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
		Task<TEntity> GetByNameAsync(string name);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(int id);
        Task RemoveRange(IEnumerable<TEntity> entities);
    }
}
