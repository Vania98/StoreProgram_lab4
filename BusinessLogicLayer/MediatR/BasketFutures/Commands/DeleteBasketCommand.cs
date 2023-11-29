using AutoMapper;
using MediatR;
using StoreProgram_lab4.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MediatR.BasketFutures.Commands
{
    //Цей код також використовує паттерн MediatR для реалізації команди DeleteBasketCommand.
    //Даний клас відповідає за обробку запиту на видалення кошика за його ідентифікатором.
    public class DeleteBasketCommand:IRequest<bool>
    {
        public int id;

        public DeleteBasketCommand(int id)
        {
            this.id = id;
        }

        public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
        {
            private readonly IUnityOfWorkRepository _unityOfWork;

            private readonly IMapper _mapper;

            private readonly IBasketRepository _basketRepository;

            public DeleteBasketCommandHandler(IUnityOfWorkRepository unityOfWork, IMapper mapper)
            {
                this._unityOfWork = unityOfWork;
                _basketRepository = this._unityOfWork._basketRepository;
                this._mapper = mapper;
            }

            public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
            {
                await _basketRepository.DeleteAsync(request.id);
                await _unityOfWork.SaveChangesAsync();
                return true;
            }
        }
    }
}
