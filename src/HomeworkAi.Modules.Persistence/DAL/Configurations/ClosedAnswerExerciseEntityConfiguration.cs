using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkAi.Modules.Persistence.DAL.Configurations;

internal sealed class ClosedAnswerExerciseEntityConfiguration : IEntityTypeConfiguration<ClosedAnswerExerciseEntity>
{
    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ExerciseHeaderInMotherLanguage).IsRequired();
        builder.Property(e => e.MotherLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguageLevel).HasMaxLength(50);
        builder.Property(e => e.TopicsOfSentences).HasMaxLength(500);
        builder.Property(e => e.GrammarSection).HasMaxLength(500);
        builder.Property(e => e.ExerciseJson).HasColumnType("jsonb");
    }
}