namespace Consimple.Database.Entities
{
    public class ClientEntity
    {
        public ClientEntity()
        {
            Checks = new List<CheckEntity>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        
        public DateTime CreateOn { get; set; }
        public DateTime? ModiliedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public ICollection<CheckEntity> Checks { get; set; }
    }
}