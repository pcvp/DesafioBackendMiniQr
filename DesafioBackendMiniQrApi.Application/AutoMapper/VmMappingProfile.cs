using AutoMapper;
using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Domain.Commands;

namespace DesafioBackendMiniQrApi.Application.AutoMapper
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateChargeInputVm, CreateChargeCommand>();
        }
    }
}
