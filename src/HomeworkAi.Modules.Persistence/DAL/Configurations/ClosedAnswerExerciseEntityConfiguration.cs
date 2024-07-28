using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkAi.Modules.Persistence.DAL.Configurations;

internal sealed class ClosedAnswerExerciseEntityConfiguration
    : IEntityTypeConfiguration<ClosedAnswerExerciseResponseQuestionsToTextEntity>,
        IEntityTypeConfiguration<ClosedAnswerExerciseResponsePassiveSideEntity>,
        IEntityTypeConfiguration<ClosedAnswerExerciseResponseParaphrasingEntity>,
        IEntityTypeConfiguration<ClosedAnswerExerciseResponseAnswerToQuestionEntity>,
        IEntityTypeConfiguration<ClosedAnswerExerciseResponseConditionalEntity>,
        IEntityTypeConfiguration<ClosedAnswerExerciseResponseWordMeaningEntity>,
        IEntityTypeConfiguration<ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity>,
        IEntityTypeConfiguration<ClosedAnswerExerciseResponseMissingPhrasalVerbEntity>,
        IEntityTypeConfiguration<ClosedAnswerExerciseResponseMissingWordOrExpressionEntity>
{
    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponseQuestionsToTextEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponsePassiveSideEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponseParaphrasingEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponseAnswerToQuestionEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponseConditionalEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponseWordMeaningEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponseMissingPhrasalVerbEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ClosedAnswerExerciseResponseMissingWordOrExpressionEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    private static void ConfigureCommonProperties<T>(EntityTypeBuilder<T> builder)
        where T : ClosedAnswerExerciseEntity
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
        builder.Property(e => e.DescriptionInMotherLanguage);
        builder.Property(e => e.ExerciseJson).HasColumnType("jsonb");
        builder.Property(e => e.CheckedByTeacher).IsRequired();
    }
}