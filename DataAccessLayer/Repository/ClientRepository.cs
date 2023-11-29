using StoreProgram_lab4.Data;
using StoreProgram_lab4.Model;
using StoreProgram_lab4.Repository.Interfaces;
using System.Data;

namespace StoreProgram_lab4.Repository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context)
        {
        }
    }
}
