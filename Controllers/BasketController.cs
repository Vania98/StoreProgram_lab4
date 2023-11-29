using BusinessLogicLayer.MediatR.BasketFutures.Commands;
using BusinessLogicLayer.MediatR.BasketFutures.Queries;
using BusinessLogiLayer.MediatR.BasketFutures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreProgram_lab4.DTO.Requests;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Service.Interfaces;

namespace StoreProgram_lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMediator _mediator;

        public BasketController(IBasketService basketService, IMediator mediator)
        {
            _basketService = basketService;
            this._mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Basket>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllBasketQuery()));
        }

        [HttpGet("GetBasketById")]
        public async Task<ActionResult<IEnumerable<BasketResponse>>> GetByBasketId(int id)
        {
            return Ok(await _mediator.Send(new GetBasketByIDQuery(id)));
        }

        [HttpPost("CreateNewBasket")]
        public async Task<ActionResult<List<Basket>>> CreateBasket([FromBody] BasketRequestcs basket)
        {
            //await _basketService.InsertAsync(basket);
            return Ok(await _mediator.Send(new CreateBasketCommand(basket)));
        }
        [HttpPut("UpadateBasket")]
        public async Task<ActionResult<List<Basket>>> UpdateBasket(int id, [FromBody]BasketRequestcs request)
        {
            //var basket = await _basketService.UpdateAsync(id, request);
            return Ok(await _mediator.Send(new UpdateBasketCommand(request,id)));
        }
        [HttpDelete("DeleteBasket")]
        public async Task<ActionResult<List<Basket>>> Delete(int id)
        {
            //await _basketService.DeleteAsync(id);
            return Ok(await _mediator.Send(new DeleteBasketCommand(id)));
        }

        [HttpGet("GetJoinBasketWithClient")]
        public async Task<IActionResult> GetBasketWithClientInfo()
        {
            var basketWithClientInfo = await _basketService.GetBasketsWithClientInfo();
            return Ok(basketWithClientInfo);
        }
    }
}
