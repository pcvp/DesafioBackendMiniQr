using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.Domain.Entities;

namespace DesafioBackendMiniQrApi.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
