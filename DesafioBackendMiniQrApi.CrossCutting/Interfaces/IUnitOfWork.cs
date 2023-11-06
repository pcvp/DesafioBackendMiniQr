using DesafioBackendMiniQrApi.CrossCutting.Commands;

namespace DesafioBackendMiniQrApi.CrossCutting.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<CommandResponse> Commit(CancellationToken cancellationToken);
    }
}
