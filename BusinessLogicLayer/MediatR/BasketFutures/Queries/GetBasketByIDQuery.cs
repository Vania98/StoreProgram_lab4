using AutoMapper;
using MediatR;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Repository.Interfaces;


namespace BusinessLogicLayer.MediatR.BasketFutures.Queries
{
    public class GetBasketByIDQuery : IRequest<BasketResponse>
    {
        //Цей код реалізує запит GetBasketByIDQuery, призначений для отримання кошика з бази даних за його унікальним ідентифікатором. 
        public int BasketId { get; }

        public GetBasketByIDQuery(int Id)
        {
            this.BasketId = Id;
        }
        public class GetBasketByIDQueryHandler : IRequestHandler<GetBasketByIDQuery, BasketResponse>
        {
            private readonly IUnityOfWorkRepository _unityOfWork;

            private readonly IMapper _mapper;

            private readonly IBasketRepository _basketRepository;

            public GetBasketByIDQueryHandler(IMapper mapper, IUnityOfWorkRepository unityOfWork)
            {
                this._unityOfWork = unityOfWork;
                _basketRepository = this._unityOfWork._basketRepository;
                this._mapper = mapper;
            }


            async Task<BasketResponse> IRequestHandler<GetBasketByIDQuery, BasketResponse>.Handle(GetBasketByIDQuery request, CancellationToken cancellationToken)
            {
                var basket = await _basketRepository.GetAsync(request.BasketId);
                return _mapper.Map<Basket, BasketResponse>(basket);
            }
        }
    }
}
