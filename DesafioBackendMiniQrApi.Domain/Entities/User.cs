using DesafioBackendMiniQrApi.CrossCutting.Models;

namespace DesafioBackendMiniQrApi.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public UserType Type { get; private set; }
        public virtual List<Charge> Charges { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        #region Factories
        public class Factory
        {
            public static User NewUser(string name, string email, UserType type)
            {
                return new User()
                {
                    Name = name,
                    Email = email,
                    Type = type
                };
            }
        }
        #endregion
    }

    public enum UserType
    {
        Administrator,
        Store
    }
}
