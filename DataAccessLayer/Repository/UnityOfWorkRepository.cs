using StoreProgram_lab4.Data;
using StoreProgram_lab4.Repository.Interfaces;

namespace StoreProgram_lab4.Repository
{
    public class UnityOfWorkRepository : IUnityOfWorkRepository
    {
        protected readonly DataContext dataContext;
        public IBasketRepository _basketRepository { get; }
        public IClientRepository _clientRepository { get; }
        public UnityOfWorkRepository(
            DataContext dataContext,
            IBasketRepository basketRepository,
            IClientRepository clientRepository)
        {
            _basketRepository = basketRepository;
            _clientRepository = clientRepository;
            this.dataContext = dataContext;

        }

        public async Task SaveChangesAsync()
        {
           await dataContext.SaveChangesAsync();
        }

    }
}
