using Devops_Auth_MicroService.Interfaces;
using Devops_Auth_MicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace Devops_Auth_MicroService.Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public AuthDbContext authDbContext;
        public DbSet<T> DbSet;
        public GenericRepository(AuthDbContext dbContext)
        {
            authDbContext = dbContext;
            DbSet = authDbContext.Set<T>();
        }
        

        public virtual Task<T> Add(T model)
        {
            DbSet.AddAsync(model);
            SaveChanges();
            return Task.FromResult(model);
        }

        public  T Get(int id)
        {
            return DbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return DbSet.Where(record => 1==1).ToList();
        }

        public Task<List<T>> GetAllAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
             authDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
