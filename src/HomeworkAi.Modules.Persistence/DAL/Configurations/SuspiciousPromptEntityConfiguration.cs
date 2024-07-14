using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkAi.Modules.Persistence.DAL.Configurations;

internal sealed class SuspiciousPromptEntityConfiguration : IEntityTypeConfiguration<SuspiciousPromptEntity>
{
    public void Configure(EntityTypeBuilder<SuspiciousPromptEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Reason).IsRequired().HasMaxLength(500);
        builder.HasIndex(e => e.Reason).HasDatabaseName("SuspiciousPrompt_NcIx_Reason");
    }
}