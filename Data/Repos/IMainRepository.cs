using DpcNtwk.API.Helpers;
using DpcNtwk.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DpcNtwk.API.Data.Repos
{
    public interface IMainRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<ICollection<T>> GetAll<T>() where T : class;
        Task<ICollection<Column>> GetColumns();
    }
}
