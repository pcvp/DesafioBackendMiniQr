using AutoMapper;
using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;
using DesafioBackendMiniQrApi.Domain.Commands;
using DesafioBackendMiniQrApi.Domain.Entities;

namespace DesafioBackendMiniQrApi.Application.AutoMapper
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateChargeInputVm, CreateChargeCommand>();
            CreateMap<CancelChargeInputVm, CancelChargeCommand>();
            CreateMap<Charge, ResultChargeVm>();

            CreateMap<CreateUserInputVm, CreateUserCommand>();
            CreateMap<User, ResultUserVm>();
        }
    }
}
