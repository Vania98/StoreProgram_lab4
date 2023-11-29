namespace StoreProgram_lab4.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> ReplacAsync(int id,T t);
        Task<bool> AddAsync(T t);

    }
}
