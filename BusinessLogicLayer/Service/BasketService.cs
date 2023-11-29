
using AutoMapper;
using StoreProgram_lab4.DTO.Requests;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Repository.Interfaces;
using StoreProgram_lab4.Service.Interfaces;

namespace StoreProgram_lab4.Service
{
    public class BasketService : IBasketService
    {
        private readonly IUnityOfWorkRepository _unityOfWork;

        private readonly IMapper _mapper;

        private readonly IBasketRepository _basketRepository;

        public BasketService(IMapper mapper, IUnityOfWorkRepository unityOfWork)
        {
            this._unityOfWork = unityOfWork;
            _basketRepository = this._unityOfWork._basketRepository;
            this._mapper = mapper;
        }
        public async Task<bool> DeleteAsync(int id)
        {   
            await _basketRepository.DeleteAsync(id);
            await _unityOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BasketResponse>> GetAll()
        {
            var baskets = await _basketRepository.GetAllAsync();
            return baskets.Select(baskets => _mapper.Map<Basket,BasketResponse>(baskets));
        }

        public async Task<BasketResponse> GetAsync(int id)
        {
            var basket = await _basketRepository.GetAsync(id);
            return _mapper.Map<Basket, BasketResponse>(basket);
        }

        public async Task<BasketResponse> InsertAsync(BasketRequestcs newBasket)
        {
            var basket = _mapper.Map<BasketRequestcs, Basket>(newBasket);
            await _basketRepository.AddAsync(basket);
            await _unityOfWork.SaveChangesAsync();
            return _mapper.Map<Basket, BasketResponse>(basket);
        }

        public async Task<IEnumerable<BasketResponse>> UpdateAsync(int id, BasketRequestcs updateBasket)
        {
            var basket = _mapper.Map<BasketRequestcs, Basket>(updateBasket);
            await _basketRepository.ReplacAsync(id, basket);
            await _unityOfWork.SaveChangesAsync();
            return await GetAll();
        }

        public async Task<IEnumerable<BasketWithClientInfoResponse>> GetBasketsWithClientInfo()
        {
            var basketsWithClientInfo = await _basketRepository.GetBasketsWithClientInfoAsync();
            return _mapper.Map<IEnumerable<BasketWithClientInfoResponse>>(basketsWithClientInfo);
        }
    }
}
