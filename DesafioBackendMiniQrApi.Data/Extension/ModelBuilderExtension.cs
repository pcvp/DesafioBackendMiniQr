using Microsoft.EntityFrameworkCore;

namespace DesafioBackendMiniQrApi.Data.Extension
{
    public static class ModelBuilderExtension
    {
        /// <summary>
        /// Force all string-based columns to non-unicode equivalent 
        /// when no column type is explicitly set.
        /// (Resumindo, passar as colunas strings para VARCHAR e não NVARCHAR)
        /// </summary>
        public static ModelBuilder SetStringToNotUnicode(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetProperties())
                            .Where(
                                   p => p.ClrType == typeof(string)    // Entity is a string
                                && p.GetColumnType() == null           // No column type is set
                            ))
            {
                property.SetIsUnicode(false);
            }

            return modelBuilder;
        }
    }
}
