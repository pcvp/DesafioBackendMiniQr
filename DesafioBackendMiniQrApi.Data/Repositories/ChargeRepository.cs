using DesafioBackendMiniQrApi.Data.Context;
using DesafioBackendMiniQrApi.Domain.Entities;
using DesafioBackendMiniQrApi.Domain.Interfaces;

namespace DesafioBackendMiniQrApi.Data.Repositories
{
    public class ChargeRepository : Repository<Charge>, IChargeRepository
    {
        public ChargeRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
