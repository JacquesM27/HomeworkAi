using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkAi.Modules.Persistence.DAL.Configurations;

internal sealed class OpenFormExerciseEntityConfiguration 
    : IEntityTypeConfiguration<OpenFormExerciseMailEntity>, 
        IEntityTypeConfiguration<OpenFormExerciseEssayEntity>,
        IEntityTypeConfiguration<OpenFormExerciseSummaryOfTextEntity>
        
{
    public void Configure(EntityTypeBuilder<OpenFormExerciseMailEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<OpenFormExerciseEssayEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<OpenFormExerciseSummaryOfTextEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    private static void ConfigureCommonProperties<T>(EntityTypeBuilder<T> builder) where T : OpenFormExerciseEntity
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ExerciseHeaderInMotherLanguage).IsRequired();
        builder.Property(e => e.MotherLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguageLevel).HasMaxLength(50);
        builder.Property(e => e.TopicsOfSentences).HasMaxLength(500);
        builder.Property(e => e.GrammarSection).HasMaxLength(500);
        builder.Property(e => e.ExerciseJson).HasColumnType("jsonb");
        builder.Property(e => e.CheckedByTeacher).IsRequired();
    }
}