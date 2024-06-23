using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Modules.OpenAi.Exercises;

//TODO: to delete - replace it with service
public abstract class ExercisePromptOld
{
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public Language MotherLanguage { get; set; }
    public Language TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string TargetAudience { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
    public string SupportMaterial { get; set; }
    public string ExerciseType { get; set; }

    public virtual string ToPrompt(string exerciseJsonFormat)
    {
        var propmpt =
            //$"2. The language of the exercise is {TargetLanguage.Value}.\n" +
            $"2. The mother's language of the student solving the exercise is {MotherLanguage.Value}.\n" +
            $"3. The exercise header (with information about exercise - not the exercise.) must be in {(ExerciseHeaderInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)}. The header is just basic information about the exercise. Don't confuse the language of the header with the language of the sentences generated. " +
            $" Also include instructions in {(ExerciseHeaderInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)} on how to perform the task correctly in the exercise header.\n" +
            //TODO: add more information about language level
            $"4. Language proficiency level is {TargetLanguageLevel}. The level of difficulty must be adapted to the exercise being generated. Based on level use appropriately difficult words in sentences.\n" +
            $"5. Target audience: {TargetAudience}";
        
        if (!string.IsNullOrWhiteSpace(TopicsOfSentences))
            propmpt += $"6. The main topic of the sentences in the exercise is/are: {TopicsOfSentences}.\n";
        else
            propmpt += $"6. The main topic of the sentences in the exercise is any.\n";
        
        if (!string.IsNullOrWhiteSpace(GrammarSection))
            propmpt += $"7. The exercise must be based on the grammatical element - {GrammarSection}. Remember to adjust the level of the grammatical element to the level of the exercise. Don't create sentences using other grammatical elements.\n";
        else
            propmpt += $"7. No grammatical elements are imposed top-down in the exercise. However, you can emphasize them keeping in mind the level of language proficiency.\n";

        if (!string.IsNullOrWhiteSpace(SupportMaterial))
            propmpt += $"8. In the support material section know these support materials: {TopicsOfSentences}.\n";
        else
            propmpt += $"8. In the support material section, generate a short summary that will be useful to the student during the exercise. Don't point out the answer there, only give hints.\n";

        propmpt += $"9. Create a short task title (do not copy it from the prompt).\n";
        propmpt += $"10. Create a short task description (do not copy it from the prompt).\n";
        propmpt += $"11. Create a correct example sentence using both languages of exercise (mother and target).\n";

        propmpt += $"""
                    12. Your responses should be structured in JSON format as follows:
                    {exerciseJsonFormat} ;
                    """;
        
        return propmpt;
    }
}

public class OpenAnswerExercisePromptOld : ExercisePromptOld
{
    public int AmountOfSentences { get; set; }
    public bool AnswersInMotherLanguage { get; set; } = false;
    
    public override string ToPrompt(string exerciseJsonFormat)
    {
        const int conditionalDenominator = 4;
        var result = (double)AmountOfSentences / conditionalDenominator;
        var roundedResult = (int)Math.Ceiling(result);
        
        var prompt = "1. This is open answer exercise.";
        prompt += ExerciseType switch
        {
            //"SentencesTranscription" => $" You need to generate {AmountOfSentences} for the student to translate. Sentences must be in {(AnswersInMotherLanguage ? TargetLanguage.Value : MotherLanguage.Value)} so that they are translatable by the student into {(AnswersInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)}.",
            //"SentenceWithVerbToCompleteBasedOnInfinitive" => $" You need to generate {AmountOfSentences} sentences with a verb to complete based on the infinitive. Replace the place of the verb in the sentence with \"____\".",
            "IrregularVerbs" => $" You need to generate {AmountOfSentences} irregular verbs with translation in mother language.",//what with language side
            "QuestionsToTextOpen" => $" You need to generate a text according to the following requirements and {AmountOfSentences} questions for this text. The questions are to be about things in the text or derived from the context of the text. " +
                                     $"Questions for the text have to be in {(AnswersInMotherLanguage ? "the student's mother language" : "a language consistent with the language of the task")}.",
            "PassiveSideOpen" => $" You need to generate {AmountOfSentences} sentences in {MotherLanguage.Value} in the passive side so that the student can translate them into {TargetLanguage.Value} independently.",
            "ParaphrasingOpen" => $" You need to generate {AmountOfSentences} sentences in {TargetLanguage.Value} so that they can be paraphrased. Transformations involve transforming sentences, that is, expressing the same thought in a different way. You need to create a sentence and add a phrasal verb to it, with the help of which the student will make the transformation.",
            "AnswerToQuestionOpen" => $" You need to generate {AmountOfSentences} questions in {TargetLanguage.Value}. According to other guidelines, the student must be able to answer them independently.",
            "ConditionalOpen" => $" You need to generate {roundedResult} sentences each in {(AnswersInMotherLanguage ? TargetLanguage.Value : MotherLanguage.Value)} so that they are translatable by the student into {(AnswersInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)}. The sentences must be in each conditional mode (zero, first, second, third) - in JSON you have list for each mode.",
            "MissingPhrasalVerbsOpen" => $" You need to generate {AmountOfSentences} sentences with phrasal verbs. Write the sentences in the CorrectSentence field. Record the correct phrasal verb in the CorrectPhrasalVerb field. In addition, in the SentenceWithUnderscoreInsteadOfPhrasalVerb field, write a sentence in which you replace phrasal verbs with ___. ",
            "MissingWordOrExpressionOpen" => $" You need to generate {AmountOfSentences} sentences in which to cut out a word or expression. Record the sentence in the CorrectSentence field. Record the correct word or phrase that will be cut in the CorrectWordOrExpression field. In addition, in the SentenceWithUnderscoreInsteadOfWordOrExpression field, write a sentence in which you will replace the word or phrase with ___. ",
            _ => throw new InvalidOperationException("type of exercise is not valid")
        };
        return prompt + base.ToPrompt(exerciseJsonFormat);
    }
}

public class ClosedAnswerExercisePromptOld : ExercisePromptOld
{
    public int AmountOfSentences { get; set; }
    public bool QuestionsInMotherLanguage { get; set; } = false;
    public bool AnswersInMotherLanguage { get; set; } = false;
    
    public override string ToPrompt(string exerciseJsonFormat)
    {
        const int conditionalDenominator = 4;
        var result = (double)AmountOfSentences / conditionalDenominator;
        var roundedResult = (int)Math.Ceiling(result);

        if (ExerciseType == "SentenceFormationClosed")
        {
            return $" 1. You need to generate {roundedResult} sentences according to the other requirements." + base.ToPrompt(exerciseJsonFormat);
        }
        
        var prompt = "1. This is closed answer exercise. This means that you need to generate responses to them from 3 to 4 according to the json format provided. Only one answer must be grammatically correct and the others are to be incorrect (have small grammatical errors).";
        prompt += ExerciseType switch
        {
            "QuestionsToTextClosed" => $" You need to generate a text according to the following requirements and {AmountOfSentences} questions for this text. The questions are to be about things in the text or derived from the context of the text. " + 
                                       $"Questions for the text have to be in {(QuestionsInMotherLanguage ? "the student's mother language" : "a language consistent with the language of the task")}. Answers for the text have to be in {(AnswersInMotherLanguage ? "the student's mother language" : "a language consistent with the language of the task")}. Remember - only one answer must be correct.",
            "PassiveSideClosed" => $" You need to generate {AmountOfSentences} sentences in {(QuestionsInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)} in the passive side so that the student can select answer in {(AnswersInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)} independently. Remember - only one answer must be correct.",
            "ParaphrasingClosed" => $" You need to generate {AmountOfSentences} sentences in {TargetLanguage.Value} so that they can be paraphrased. Transformations involve transforming sentences, that is, expressing the same thought in a different way. You need to create a sentence and add a phrasal verb to it, with the help of which the student will choose the correct answer with transformation. Remember - only one answer must be correct.",
            "AnswerToQuestionClosed" => $" You need to generate {AmountOfSentences} questions in {(QuestionsInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)} and then you must generate the answers to those questions in {(AnswersInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)}. Remember - only one answer must be correct.",
            "ConditionalClosed" => $" You need to generate {roundedResult} sentences each in {(QuestionsInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)}. Answers for the text have to be in {(AnswersInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)}. The sentences must be in each conditional mode (zero, first, second, third) - in JSON you have list for each mode. Remember - only one answer must be correct.",
            "WordMeaning" => $" You need to generate {roundedResult} words in {(QuestionsInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)} and their correct meanings in {(AnswersInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)}. Remember - only one answer must be correct.",
            "PhrasalVerbsTranslating" => $" You need to generate {AmountOfSentences} sentences in {(QuestionsInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)} with the phrasal verb so that the student can select answer in {(AnswersInMotherLanguage ? MotherLanguage.Value : TargetLanguage.Value)} independently. Remember - only one answer must be correct.",
            "MissingPhrasalVerbsClosed" => $" You need to generate {AmountOfSentences} sentences with phrasal verbs. Replace phrasal verb with \"___\". Then generate 3 or 4 answers (one answer must be a cut phrasal verb from the original sentence), remember that only one of the answers must be correct.",
            "MissingWordOrExpressionClosed" => $" You need to generate {AmountOfSentences} sentences in which to cut out a word or expression. Replace word or expression with \"___\". Then generate 3 or 4 answers (one answer must be a cut word or expression from the original sentence), remember that only one of the answers must be correct.",
            _ => throw new InvalidOperationException("type of exercise is not valid")
        };
        return prompt + base.ToPrompt(exerciseJsonFormat);
    }
}