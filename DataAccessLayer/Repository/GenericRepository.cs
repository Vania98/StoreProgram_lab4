using System.Data.SqlClient;
using StoreProgram_lab4.Repository.Interfaces;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using StoreProgram_lab4.Data;
using Microsoft.EntityFrameworkCore;

namespace StoreProgram_lab4.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        protected static string GetEntityNotFoundErrorMessage(int id) =>
            $"{typeof(T).Name} with id {id} not found.";


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id)
                ?? throw new Exception(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.FindAsync<T>(id);
            if(entity == null)
            {
                return false;
            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddAsync(T t)
        {
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> ReplacAsync(int id,T t)
        {
            var entry = _context.Entry(t);
            if (entry.State == EntityState.Detached)
            {
                var existingEntity = await _context.Set<T>().FindAsync(id);
                if (existingEntity == null)
                    return false;
                _context.Entry(existingEntity).CurrentValues.SetValues(t);
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
