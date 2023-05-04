using Consimple.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consimple.EntityFramework.Configurations
{
    public class CheckConfiguration : IEntityTypeConfiguration<CheckEntity>
    {
        public void Configure(EntityTypeBuilder<CheckEntity> builder)
        {
            builder.ToTable("Checks").HasKey(check => check.Id);

            builder.HasMany<ProductEntity>(check => check.Products)
                .WithOne(product => product.Check)
                .HasForeignKey(product => product.CheckFK);
        }
    }
}