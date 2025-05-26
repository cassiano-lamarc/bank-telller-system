using BankTellerSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankTellerSystem.InfraData.Mappings;

public class AccountHistoryMap : IEntityTypeConfiguration<AccountHistory>
{
    public void Configure(EntityTypeBuilder<AccountHistory> builder)
    {
        builder.HasKey(a => a.Guid);

        builder.Property(a => a.Guid)
            .ValueGeneratedOnAdd();

        builder.HasOne(a => a.Account)
            .WithMany(a => a.AccountHistories)
            .HasForeignKey(a => a.AccountId);
    }
}
