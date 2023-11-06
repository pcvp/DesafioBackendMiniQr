using DesafioBackendMiniQrApi.CrossCutting.Models;

namespace DesafioBackendMiniQrApi.CrossCutting.Interfaces
{
    public interface IStrategy
    {
        Task<bool> Process<T>(T entity, T? source) where T : Entity;
    }
}
