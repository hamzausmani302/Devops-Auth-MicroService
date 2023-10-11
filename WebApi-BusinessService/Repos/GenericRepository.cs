using WebApi_BusinessService.Interfaces;
using WebApi_BusinessService.Models;
using Microsoft.EntityFrameworkCore;

namespace Devops_Auth_MicroService.Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public AuthDbContext1 authDbContext;
        public DbSet<T> DbSet;
        public GenericRepository(AuthDbContext1 dbContext)
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

        public async Task<List<T>> GetAllAsync(int id)
        {
            List<T> r = await DbSet.Where(record => 1 == 1).ToListAsync();
            return r;
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

        public async Task<bool> Update(T entity)
        {
            try
            {
                DbSet.Update(entity);
                await Task.CompletedTask;
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            }
    }
}
