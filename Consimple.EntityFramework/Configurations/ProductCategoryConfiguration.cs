using Consimple.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consimple.EntityFramework.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.ToTable("ProductCategories").HasKey(pc => new { pc.CategoryFK, pc.ProductFK });

            builder.HasOne<ProductEntity>(pc => pc.Product)
                .WithMany(product => product.Categories)
                .HasForeignKey(pc => pc.ProductFK);

            builder.HasOne<CategoryEntity>(pc => pc.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(pc => pc.CategoryFK);
        }
    }
}