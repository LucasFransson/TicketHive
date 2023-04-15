﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void RemoveRange(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
    }
}
