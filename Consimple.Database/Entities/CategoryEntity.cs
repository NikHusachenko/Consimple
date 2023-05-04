namespace Consimple.Database.Entities
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {
            Products = new List<ProductCategoryEntity>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductCategoryEntity> Products { get; set; }
    }
}