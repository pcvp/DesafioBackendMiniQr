using DesafioBackendMiniQrApi.CrossCutting.Models;
using DesafioBackendMiniQrApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackendMiniQrApi.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(Table.User.Name, Table.User.Schema);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Email).IsRequired();

            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}