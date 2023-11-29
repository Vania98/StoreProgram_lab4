using AutoMapper;
using MediatR;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Repository.Interfaces;


namespace BusinessLogiLayer.MediatR.BasketFutures.Queries
{
    public class GetAllBasketQuery : IRequest<IEnumerable<BasketResponse>>
    {
        //Цей код реалізує запит GetAllBasketQuery для отримання всіх кошиків з бази даних.
        public class GetAllBasketQueryHandler : IRequestHandler<GetAllBasketQuery, IEnumerable<BasketResponse>>
        {
            private readonly IUnityOfWorkRepository _unityOfWork;

            private readonly IMapper _mapper;

            private readonly IBasketRepository _basketRepository;

            public GetAllBasketQueryHandler(IMapper mapper, IUnityOfWorkRepository unityOfWork)
            {
                this._unityOfWork = unityOfWork;
                _basketRepository = this._unityOfWork._basketRepository;
                this._mapper = mapper;
            }


            async Task<IEnumerable<BasketResponse>> IRequestHandler<GetAllBasketQuery, IEnumerable<BasketResponse>>.Handle(GetAllBasketQuery request, CancellationToken cancellationToken)
            {
                var baskets = await _basketRepository.GetAllAsync();
                return baskets.Select(baskets => _mapper.Map<Basket, BasketResponse>(baskets));
            }
        }
    }
}
