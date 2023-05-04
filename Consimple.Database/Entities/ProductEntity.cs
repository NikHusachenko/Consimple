namespace Consimple.Database.Entities
{
    public class ProductEntity
    {
        public ProductEntity()
        {
            Categories = new List<ProductCategoryEntity>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModiliedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public long? CheckFK { get; set; }
        public CheckEntity Check { get; set; }

        public ICollection<ProductCategoryEntity> Categories { get; set; }
    }
}