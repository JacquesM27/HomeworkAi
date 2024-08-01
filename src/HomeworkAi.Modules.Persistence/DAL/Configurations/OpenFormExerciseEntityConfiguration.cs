using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkAi.Modules.Persistence.DAL.Configurations;

internal sealed class OpenFormExerciseEntityConfiguration
    : IEntityTypeConfiguration<MailEntity>,
        IEntityTypeConfiguration<EssayEntity>,
        IEntityTypeConfiguration<SummaryOfTextEntity>

{
    public void Configure(EntityTypeBuilder<MailEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<EssayEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<SummaryOfTextEntity> builder)
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
        builder.Property(e => e.AverageRating).IsRequired();
        builder.Property(e => e.RatingCount).IsRequired();
    }
}