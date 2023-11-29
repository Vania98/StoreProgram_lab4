using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using StoreProgram_lab4.DTO.Requests;
using StoreProgram_lab4.DTO.Responses;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Repository.Interfaces;
using StoreProgram_lab4.Service.Interfaces;

namespace StoreProgram_lab4.Service
{
    public class ClientService : IClientService
    {
        private readonly IUnityOfWorkRepository _unityOfWork;
        
        private readonly IMapper _mapper;

        private readonly IClientRepository _clientRepository;

        public ClientService(IMapper mapper,IUnityOfWorkRepository unityOfWork, IClientRepository clientRepository)
        {
            this._unityOfWork = unityOfWork;
            _clientRepository = this._unityOfWork._clientRepository;
            this._mapper = mapper;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
            await _unityOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ClientResponse>> GetAll()
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients.Select(clients => _mapper.Map<Client, ClientResponse>(clients));
        }

        public async Task<ClientResponse> GetAsync(int id)
        {
            var client = await _clientRepository.GetAsync(id);
            return _mapper.Map<Client, ClientResponse>(client);
        }

        public async Task<ClientResponse> InsertAsync(ClientRequest newClient)
        {
           var client = _mapper.Map<ClientRequest, Client>(newClient);
            await _clientRepository.AddAsync(client);
            await _unityOfWork.SaveChangesAsync();
            return _mapper.Map<Client, ClientResponse>(client);
        }

        public async Task<IEnumerable<ClientResponse>> UpdateAsync(int id, ClientRequest updateClient)
        {
            var client = _mapper.Map<ClientRequest,Client>(updateClient);
            await _clientRepository.ReplacAsync(id, client);
            await _unityOfWork.SaveChangesAsync();
            return await GetAll();
        }
    }
}
