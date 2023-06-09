﻿namespace Consimple.Database.Entities
{
    public class CheckEntity
    {
        public CheckEntity()
        {
            Products = new List<ProductEntity>();
        }

        public long Id { get; set; }
        public bool IsClosed { get; set; }
        
        public long ClientFK { get; set; }
        public ClientEntity Client { get; set; }

        public DateTime OpenedOn { get; set; }
        public DateTime? ClosedOn { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

    }
}