using StoreProgram_lab4.DTO.Requests;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;

namespace StoreProgram_lab4.Service.Interfaces
{
    public interface IBasketService
    {
        Task<IEnumerable<BasketResponse>> GetAll();
        Task <BasketResponse> GetAsync(int id);
        Task <bool> DeleteAsync(int id);
        Task<IEnumerable<BasketResponse>> UpdateAsync(int id,BasketRequestcs basket);
        Task<BasketResponse> InsertAsync(BasketRequestcs basket);
        Task<IEnumerable<BasketWithClientInfoResponse>> GetBasketsWithClientInfo();
    }
}
