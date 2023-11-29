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
//це паттерн проектування, який дозволяє зменшити прямі зв'язки між об'єктами, замість цього прокладаючи шлях через об'єкт-посередника.
//Це сприяє покращенню модульності та зменшенню залежностей між компонентами системи.
//Основна ідея полягає в тому, що кожен об'єкт взаємодіє лише з посередником, а не напряму з іншими об'єктами,
//спрощуючи тим самим взаємодію між ними.
namespace BusinessLogicLayer.MediatR.BasketFutures.Commands
{
    public class CreateBasketCommand:IRequest<BasketResponse>
    {
        public BasketRequestcs Basket { get; set; }

        public CreateBasketCommand(BasketRequestcs basket)
        {
            this.Basket = basket;
        }
        //цей код відноситься до патерну MediatR, де команда CreateBasketCommand обробляється класом CreateBasketCommandHandler.
        //Основна функція - створення кошика (Basket) на основі отриманих даних з запиту BasketRequestcs та збереження його в репозиторії.
        public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, BasketResponse>
        {
            private readonly IUnityOfWorkRepository _unityOfWork;

            private readonly IMapper _mapper;

            private readonly IBasketRepository _basketRepository;

            public CreateBasketCommandHandler(IUnityOfWorkRepository unityOfWork, IMapper mapper)
            {
                this._unityOfWork = unityOfWork;
                _basketRepository = this._unityOfWork._basketRepository;
                this._mapper = mapper;
            }


            async Task<BasketResponse> IRequestHandler<CreateBasketCommand, BasketResponse>.Handle(CreateBasketCommand request, CancellationToken cancellationToken)
            {
                var basket = _mapper.Map<BasketRequestcs, Basket>(request.Basket);
                await _basketRepository.AddAsync(basket);
                await _unityOfWork.SaveChangesAsync();
                return _mapper.Map<Basket, BasketResponse>(basket);
            }
        }
    }
}
