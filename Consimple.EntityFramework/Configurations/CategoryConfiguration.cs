using Consimple.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consimple.EntityFramework.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories").HasKey(category => category.Id);

            builder.Property(category => category.Name).HasMaxLength(63).IsRequired(true);
        }
    }
}