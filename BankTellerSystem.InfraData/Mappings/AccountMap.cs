using BankTellerSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankTellerSystem.InfraData.Mappings;

public class AccountMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Guid);

        builder.Property(a => a.Guid)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(a => a.ClientGuid)
            .IsRequired();

        builder.HasOne(a => a.Client)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.ClientGuid);
    }
}
