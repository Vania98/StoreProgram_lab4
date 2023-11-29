using Microsoft.EntityFrameworkCore;
using StoreProgram_lab4.Data;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Repository.Interfaces;

namespace StoreProgram_lab4.Repository
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
       private readonly DataContext _dataContext;

        public BasketRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public async Task<IEnumerable<Basket>> GetBasketsWithClientInfoAsync()
        {
            var basketsWithClientInfo = await _dataContext.Baskets
                .Include(basket => basket.Client)
                .ToListAsync();
            return basketsWithClientInfo;
        }
    }
}
