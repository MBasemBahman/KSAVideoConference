using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KSAVideoConference.BaseRepository
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIDAsync(int id);

        bool Any();

        bool Any(Expression<Func<T, bool>> expression);

        void CreateEntityAsync(T entity);

        T CreateEntity(T entity);

        void CreateEntityAsync(List<T> entities);

        void UpdateEntity(T entity);

        void UpdateEntity(List<T> entities);

        void DeleteEntity(List<T> entities);

        Task<int> SaveAsync();

        void DisposeAsync();
    }
}
