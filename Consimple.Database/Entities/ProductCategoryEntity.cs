namespace Consimple.Database.Entities
{
    public class ProductCategoryEntity
    {
        public long ProductFK { get; set; }
        public ProductEntity Product { get; set; }

        public long CategoryFK { get; set; }
        public CategoryEntity Category { get; set; }
    }
}