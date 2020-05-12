using KSAVideoConference.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KSAVideoConference.BaseRepository
{
    public abstract class AppBaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext MedicalAppContext;

        public AppBaseRepository(DataContext DBContext)
        {
            MedicalAppContext = DBContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await MedicalAppContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await MedicalAppContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await MedicalAppContext.Set<T>().FindAsync(id);
        }

        public void CreateEntityAsync(T entity)
        {
            MedicalAppContext.Set<T>().AddAsync(entity);
        }

        public T CreateEntity(T entity)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> Entity = MedicalAppContext.Set<T>().Add(entity);
            return Entity.Entity;
        }

        public void CreateEntityAsync(List<T> entities)
        {
            MedicalAppContext.Set<T>().AddRangeAsync(entities);
        }

        public void UpdateEntity(T entity)
        {
            MedicalAppContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public void UpdateEntity(List<T> entities)
        {
            foreach (T entity in entities)
            {
                MedicalAppContext.Entry<T>(entity).State = EntityState.Modified;
            }
        }

        public void DeleteEntity(T entity)
        {
            MedicalAppContext.Set<T>().Remove(entity);
        }

        public void DeleteEntity(List<T> entities)
        {
            MedicalAppContext.Set<T>().RemoveRange(entities);
        }

        public async Task<int> SaveAsync()
        {
            return await MedicalAppContext.SaveChangesAsync();
        }

        public int Save()
        {
            return MedicalAppContext.SaveChanges();
        }

        public void DisposeAsync()
        {
            MedicalAppContext.DisposeAsync();
        }

        public bool Any()
        {
            return MedicalAppContext.Set<T>().Any();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return MedicalAppContext.Set<T>().Where(expression).Any();
        }
    }
}
