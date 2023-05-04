namespace Consimple.Database.Entities
{
    public class CheckEntity
    {
        public CheckEntity()
        {
            Products = new List<ProductEntity>();
        }

        public long Id { get; set; }
        
        public long ClientFK { get; set; }
        public ClientEntity Client { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

    }
}