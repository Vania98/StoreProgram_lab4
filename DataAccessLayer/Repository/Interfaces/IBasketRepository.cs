using StoreProgram_lab4.Model;

namespace StoreProgram_lab4.Repository.Interfaces
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Task<IEnumerable<Basket>> GetBasketsWithClientInfoAsync();
    }
}
