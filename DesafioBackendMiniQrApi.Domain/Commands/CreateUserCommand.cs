using DesafioBackendMiniQrApi.Domain.Entities;
using MediatR;

namespace DesafioBackendMiniQrApi.Domain.Commands
{
    public class CreateUserCommand : IRequest<User?>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public UserType Type { get; set; }
    }
}
