using Consimple.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consimple.EntityFramework.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products").HasKey(product => product.Id);

            builder.Property(product => product.Name).HasMaxLength(63).IsRequired(true);
        }
    }
}