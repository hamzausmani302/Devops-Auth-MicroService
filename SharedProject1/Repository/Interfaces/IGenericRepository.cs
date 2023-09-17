namespace Devops_Auth_MicroService.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        public List<T> GetAll();
        public Task<List<T>> GetAllAsync(int id);
        public T Get(int id);

        public Task<T> GetAsync(int id);
        public Task<bool> Update(T entity);
        public Task<bool> Remove(T entity);
        Task<T> Add(T model);

        public Task SaveChanges();
    }
}
