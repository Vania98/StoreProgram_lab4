namespace StoreProgram_lab4.Repository.Interfaces
{
    public interface IUnityOfWorkRepository
    {
        IBasketRepository _basketRepository { get; }
        IClientRepository _clientRepository { get; }

        Task SaveChangesAsync();
    }
}
