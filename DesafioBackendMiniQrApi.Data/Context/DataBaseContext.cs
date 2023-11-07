using DesafioBackendMiniQrApi.Data.Extension;
using DesafioBackendMiniQrApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackendMiniQrApi.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
           : base(options)
        {
        }

        public DbSet<Charge> Charges { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.SetStringToNotUnicode();
        }

        public override int SaveChanges()
        {
            throw new InvalidOperationException("Use SaveChangesAsync.");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            OnBeforeSaving();

            int affectedRows = await base.SaveChangesAsync(cancellationToken);

            return affectedRows;
        }

        private void OnBeforeSaving()
        {
            CreateDateRerwite();
        }

        private void CreateDateRerwite()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.CurrentValues["CreatedAtUtc"] = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.CurrentValues["UpdatedAtUtc"] = DateTime.UtcNow;
                }
            }
        }
    }
}