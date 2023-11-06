using BaseService.Infra.CrossCutting.Models;

namespace DesafioBackendMiniQrApi.Domain.Entities
{
    public class Charge : Entity
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
