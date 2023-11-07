using DesafioBackendMiniQrApi.Domain.Entities;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Results
{
    public class ResultUserVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Type { get; set; }
    }
}
