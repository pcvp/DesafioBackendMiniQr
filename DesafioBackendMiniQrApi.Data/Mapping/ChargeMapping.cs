using DesafioBackendMiniQrApi.CrossCutting.Models;
using DesafioBackendMiniQrApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackendMiniQrApi.Data.Mapping
{
    public class ChargeMapping : IEntityTypeConfiguration<Charge>
    {
        public void Configure(EntityTypeBuilder<Charge> builder)
        {
            builder.ToTable(Table.Charge.Name, Table.Charge.Schema);

            builder.Property(c => c.Value).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.CancelledByUserId).HasDefaultValue(null);

            builder.HasOne(c => c.User)
                .WithMany(u => u.Charges)
                .HasForeignKey(c => c.UserId);
        }
    }
}