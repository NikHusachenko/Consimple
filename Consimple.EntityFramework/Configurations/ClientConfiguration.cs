using Consimple.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consimple.EntityFramework.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("Clients").HasKey(client => client.Id);

            builder.HasMany<CheckEntity>(client => client.Checks)
                .WithOne(check => check.Client)
                .HasForeignKey(check => check.ClientFK);

            builder.Property(client => client.FirstName).HasMaxLength(63).IsRequired(true);
            builder.Property(client => client.LastName).HasMaxLength(63).IsRequired(true);
            builder.Property(client => client.MiddleName).HasMaxLength(63).IsRequired(true);
        }
    }
}