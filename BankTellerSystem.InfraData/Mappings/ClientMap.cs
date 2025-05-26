using BankTellerSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankTellerSystem.InfraData.Mappings;

public class ClientMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Guid);

        builder.Property(c => c.Guid)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(c => c.Doc)
            .HasMaxLength(100)
            .IsRequired();
    }
}
