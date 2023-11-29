using StoreProgram_lab4.DTO.Requests;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;

namespace StoreProgram_lab4.Service.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientResponse>> GetAll();
        Task<ClientResponse> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ClientResponse>> UpdateAsync(int id, ClientRequest newClient);
        Task<ClientResponse> InsertAsync(ClientRequest updateClient);
    }
}
