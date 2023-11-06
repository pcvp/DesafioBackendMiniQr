using DesafioBackendMiniQrApi.Domain.Entities;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Results
{
    public class ResultCreateChargeVm
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal Value { get; set; }
        public string? QrCode { get; set; }
    }
}
