using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkAi.Modules.Persistence.DAL.Configurations;

internal sealed class OpenFormExerciseEntityConfiguration : IEntityTypeConfiguration<OpenFormExerciseEntity>
{
    public void Configure(EntityTypeBuilder<OpenFormExerciseEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ExerciseHeaderInMotherLanguage).IsRequired();
        builder.Property(e => e.MotherLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguageLevel).HasMaxLength(50);
        builder.Property(e => e.TopicsOfSentences).HasMaxLength(500);
        builder.Property(e => e.GrammarSection).HasMaxLength(500);
        builder.Property(e => e.ExerciseType).IsRequired().HasMaxLength(100);
        builder.Property(e => e.ExerciseJson).HasColumnType("jsonb");
        builder.Property(e => e.CheckedByTeacher).IsRequired();
        
        builder.HasIndex(e => e.ExerciseType).HasDatabaseName("OpenForm_NcIx_ExerciseType");
    }
}