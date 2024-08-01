using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkAi.Modules.Persistence.DAL.Configurations;

internal sealed class OpenAnswerExerciseEntityConfiguration
    : IEntityTypeConfiguration<SentencesTranslationEntity>,
        IEntityTypeConfiguration<SentenceWithVerbToCompleteBasedOnInfinitiveEntity>,
        IEntityTypeConfiguration<SentenceWithVerbToCompleteEntity>,
        IEntityTypeConfiguration<IrregularVerbsEntity>,
        IEntityTypeConfiguration<QuestionsToTextOpenEntity>,
        IEntityTypeConfiguration<PassiveSideOpenEntity>,
        IEntityTypeConfiguration<ParaphrasingOpenEntity>,
        IEntityTypeConfiguration<AnswerToQuestionOpenEntity>,
        IEntityTypeConfiguration<ConditionalOpenEntity>,
        IEntityTypeConfiguration<MissingPhrasalVerbOpenEntity>,
        IEntityTypeConfiguration<MissingWordOrExpressionOpenEntity>,
        IEntityTypeConfiguration<WordMeaningOpenEntity>
{
    private static void ConfigureCommonProperties<T>(EntityTypeBuilder<T> builder) where T : OpenAnswerExerciseEntity
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ExerciseHeaderInMotherLanguage).IsRequired();
        builder.Property(e => e.MotherLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguageLevel).HasMaxLength(50);
        builder.Property(e => e.TopicsOfSentences).HasMaxLength(500);
        builder.Property(e => e.GrammarSection).HasMaxLength(500);
        builder.Property(e => e.AmountOfSentences);
        builder.Property(e => e.TranslateFromMotherLanguage);
        builder.Property(e => e.QuestionsInMotherLanguage);
        builder.Property(e => e.ZeroConditional);
        builder.Property(e => e.FirstConditional);
        builder.Property(e => e.SecondConditional);
        builder.Property(e => e.ThirdConditional);
        builder.Property(e => e.ShowMotherLanguage);
        builder.Property(e => e.ShowFirstForm);
        builder.Property(e => e.ExerciseJson).HasColumnType("jsonb");
        builder.Property(e => e.CheckedByTeacher).IsRequired();
        builder.Property(e => e.AverageRating).IsRequired();
        builder.Property(e => e.RatingCount).IsRequired();
    }

    public void Configure(EntityTypeBuilder<SentencesTranslationEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<SentenceWithVerbToCompleteBasedOnInfinitiveEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<SentenceWithVerbToCompleteEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<IrregularVerbsEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<QuestionsToTextOpenEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<PassiveSideOpenEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ParaphrasingOpenEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<AnswerToQuestionOpenEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ConditionalOpenEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<MissingPhrasalVerbOpenEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<MissingWordOrExpressionOpenEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<WordMeaningOpenEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }
}