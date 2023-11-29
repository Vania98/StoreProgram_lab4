using AutoMapper;
using MediatR;
using StoreProgram_lab4.DTO.Requests;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MediatR.BasketFutures.Commands
{
    //Цей код реалізує команду UpdateBasketCommand з використанням MediatR для оновлення існуючого кошика.
    public class UpdateBasketCommand:IRequest<BasketResponse>
    {
        public BasketRequestcs BasketRequestcs { get; set; }
        
        public int Id { get; set; }

        public UpdateBasketCommand(BasketRequestcs basketRequestcs, int id)
        {
            this.BasketRequestcs = basketRequestcs;
            this.Id = id;
        }

        public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, BasketResponse>
        {
            private readonly IUnityOfWorkRepository _unityOfWork;

            private readonly IMapper _mapper;

            private readonly IBasketRepository _basketRepository;

            public UpdateBasketCommandHandler(IUnityOfWorkRepository unityOfWork, IMapper mapper)
            {
                this._unityOfWork = unityOfWork;
                _basketRepository = this._unityOfWork._basketRepository;
                this._mapper = mapper;
            }
            public async Task<BasketResponse> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            {
                var basket = _mapper.Map<BasketRequestcs, Basket>(request.BasketRequestcs);
                await _basketRepository.ReplacAsync(request.Id, basket);
                await _unityOfWork.SaveChangesAsync();
                return _mapper.Map<Basket,BasketResponse>(basket);
            }
        }
    }
}
