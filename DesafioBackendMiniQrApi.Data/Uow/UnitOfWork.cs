using DesafioBackendMiniQrApi.CrossCutting.Commands;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.Data.Context;

namespace DesafioBackendMiniQrApi.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<CommandResponse> Commit(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0 ? 
                new CommandResponse(true) : 
                new CommandResponse(false);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
