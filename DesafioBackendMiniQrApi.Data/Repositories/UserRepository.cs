using DesafioBackendMiniQrApi.Data.Context;
using DesafioBackendMiniQrApi.Domain.Entities;
using DesafioBackendMiniQrApi.Domain.Interfaces;

namespace DesafioBackendMiniQrApi.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
