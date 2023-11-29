using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreProgram_lab4.DTO.Requests;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Repository.Interfaces;
using StoreProgram_lab4.Service.Interfaces;

namespace StoreProgram_lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            this._clientService = clientService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Client>>> GetAllGeneric()
        {
            return Ok(await _clientService.GetAll());
        }

        [HttpGet("GeClientByID")]
        public async Task<ActionResult<IEnumerable<ClientResponse>>> GetByClientID(int id)
        {
            return Ok(await _clientService.GetAsync(id));
        }

        [HttpPost("CreateNewClient")]
        public async Task<ActionResult<List<Client>>> AddClient([FromBody] ClientRequest client)
        {

            await _clientService.InsertAsync(client);

            return Ok(await _clientService.GetAll());
        }
        [HttpPut("UpdateClient")]
        public async Task<ActionResult<List<Client>>> UpdateClient(int id ,[FromBody]ClientRequest request)
        {
            await _clientService.UpdateAsync(id, request);

            return Ok(await _clientService.GetAll());
        }
        [HttpDelete("DeleteClient")]
        public async Task<ActionResult<List<Client>>> Delete(int id)
        {
            await _clientService.DeleteAsync(id);

            return Ok(await _clientService.GetAll());
        }

    }
}
