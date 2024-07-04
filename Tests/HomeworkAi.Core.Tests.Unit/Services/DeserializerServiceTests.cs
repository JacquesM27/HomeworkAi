
using System.Text.Json;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Cache;
using HomeworkAi.Modules.OpenAi.Services;

public class DeserializerServiceTests
{
    private readonly IDeserializerService _service;

    public DeserializerServiceTests()
    {
        var samplerService = new ObjectSamplerService();
        var memoryCache = new ApplicationMemoryCache();
        _service = new DeserializerService(samplerService, memoryCache);
    }
    
    private string RemoveWhitespace(string input)
    {
      return string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
    }
    
    // [Fact]
    // public void FixJson_ShouldAddCommaBetweenObjects()
    // {
    //     string input = @"{
    //         ""value1"": false
    //         ""value2"": ""ok""
    //     }";
    //     string expected = @"{
    //         ""value1"": false,
    //         ""value2"": ""ok""
    //     }";
    //
    //     string result = _service.FixJson(input);
    //
    //     //Assert.Equal(expected, result);
    //     Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }
    //
    // [Fact]
    // public void FixJson_ShouldAddCommaBetweenObjectsMixed()
    // {
    //   string input = @"{
    //         ""value1"": false
    //         ""value2"": ""ok""
    //         ""value3"": 3,
    //         ""value4"": 4
    //     }";
    //   string expected = @"{
    //         ""value1"": false,
    //         ""value2"": ""ok"",
    //         ""value3"": 3,
    //         ""value4"": 4
    //     }";
    //
    //   string result = _service.FixJson(input);
    //
    //   //Assert.Equal(expected, result);
    //   Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }
    //
    // [Fact]
    // public void FixJson_ShouldAddCommaBetweenMoreThanTwoObjects()
    // {
    //   string input = @"{
    //         ""valuee1"": false
    //         ""value1"": false
    //         ""value2"": ""ok""
    //         ""value2"": ""ok""
    //     }";
    //   string expected = @"{
    //         ""valuee1"": false,
    //         ""value1"": false,
    //         ""value2"": ""ok"",
    //         ""value2"": ""ok""
    //     }";
    //
    //   string result = _service.FixJson(input);
    //
    //   //Assert.Equal(expected, result);
    //   Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }
    
    // [Fact]
    // public void FixJson_ShouldAddCommaBetweenMoreThanTwoObjectsMixed()
    // {
    //   string input = @"{
    //         ""value1"": false
    //         ""v2"": false,
    //         ""value1"": false
    //         ""b4"": ""ok"",
    //         ""value2"": ""ok""
    //     }";
    //   string expected = @"{
    //         ""value1"": false,
    //         ""v2"": false,
    //         ""value1"": false,
    //         ""b4"": ""ok"",
    //         ""value2"": ""ok""
    //     }";
    //
    //   string result = _service.FixJson(input);
    //
    //   //Assert.Equal(expected, result);
    //   Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }
    //
    // [Fact]
    // public void FixJson_ShouldAddCommaBetweenNestedObjects()
    // {
    //     string input = @"{
    //         ""value1"": false
    //         ""value2"": ""ok"",
    //         ""value3"": 29,
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false
    //         }
    //     }";
    //     string expected = @"{
    //         ""value1"": false,
    //         ""value2"": ""ok"",
    //         ""value3"": 29,
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false
    //         }
    //     }";
    //
    //     string result = _service.FixJson(input);
    //
    //     //Assert.Equal(expected, result);
    //     Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }
    [Fact]
    public void FixJson_ShouldAddCommaBetweenExercises()
    {
        string input = """
                       {
                       	"SentencesWithPhrasalVerb": [{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "Her ___ to the challenging situation impressed everyone.",
                       			"CorrectPhrasalVerb": "rise to",
                       			"CorrectSentence": "Her rise to the challenging situation impressed everyone."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "The speaker will ___ important topics during the conference.",
                       			"CorrectPhrasalVerb": "touch on",
                       			"CorrectSentence": "The speaker will touch on important topics during the conference."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "They need to ___ alternative solutions to the problem.",
                       			"CorrectPhrasalVerb": "come up with",
                       			"CorrectSentence": "They need to come up with alternative solutions to the problem."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "The artist ___ his work to showcase his talent.",
                       			"CorrectPhrasalVerb": "put forward",
                       			"CorrectSentence": "The artist put forward his work to showcase his talent."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "She can ___ others' perspectives easily."
                       			"CorrectPhrasalVerb": "take in",
                       			"CorrectSentence": "She can take in others' perspectives easily."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "The team plans to ___ a new project next month."
                       			"CorrectPhrasalVerb": "roll out",
                       			"CorrectSentence": "The team plans to roll out a new project next month."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "He will ___ for his mistakes and work to improve."
                       			"CorrectPhrasalVerb": "own up",
                       			"CorrectSentence": "He will own up for his mistakes and work to improve."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "The company plans to ___ a new strategy for growth."
                       			"CorrectPhrasalVerb": "put together",
                       			"CorrectSentence": "The company plans to put together a new strategy for growth."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "She always ___ new ideas for the project."
                       			"CorrectPhrasalVerb": "come up with",
                       			"CorrectSentence": "She always comes up with new ideas for the project."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "They must ___ the problem before making a decision."
                       			"CorrectPhrasalVerb": "get to grips with",
                       			"CorrectSentence": "They must get to grips with the problem before making a decision."
                       		}
                       	],
                       	"Header": {
                       		"Title": "Ćwiczenie na czasowniki frazowe - Poziom Zaawansowany"
                       		"TaskDescription": "Uzupełnij zdania odpowiednimi czasownikami frazowymi na poziomie zaawansowanym.",
                       		"Instruction": "Dobierz właściwy czasownik frazowy do każdego zdania.",
                       		"Example": "Przykład: Her rise to the challenging situation impressed everyone.",
                       		"SupportMaterial": "Wykorzystaj swoje umiejętności na poziomie zaawansowanym do poprawnego użycia czasowników frazowych w kontekście."
                       	}
                       }
                       """;
        string expected = """
                       {
                       	"SentencesWithPhrasalVerb": [{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "Her ___ to the challenging situation impressed everyone.",
                       			"CorrectPhrasalVerb": "rise to",
                       			"CorrectSentence": "Her rise to the challenging situation impressed everyone."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "The speaker will ___ important topics during the conference.",
                       			"CorrectPhrasalVerb": "touch on",
                       			"CorrectSentence": "The speaker will touch on important topics during the conference."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "They need to ___ alternative solutions to the problem.",
                       			"CorrectPhrasalVerb": "come up with",
                       			"CorrectSentence": "They need to come up with alternative solutions to the problem."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "The artist ___ his work to showcase his talent.",
                       			"CorrectPhrasalVerb": "put forward",
                       			"CorrectSentence": "The artist put forward his work to showcase his talent."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "She can ___ others' perspectives easily.",
                       			"CorrectPhrasalVerb": "take in",
                       			"CorrectSentence": "She can take in others' perspectives easily."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "The team plans to ___ a new project next month.",
                       			"CorrectPhrasalVerb": "roll out",
                       			"CorrectSentence": "The team plans to roll out a new project next month."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "He will ___ for his mistakes and work to improve.",
                       			"CorrectPhrasalVerb": "own up",
                       			"CorrectSentence": "He will own up for his mistakes and work to improve."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "The company plans to ___ a new strategy for growth.",
                       			"CorrectPhrasalVerb": "put together",
                       			"CorrectSentence": "The company plans to put together a new strategy for growth."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "She always ___ new ideas for the project.",
                       			"CorrectPhrasalVerb": "come up with",
                       			"CorrectSentence": "She always comes up with new ideas for the project."
                       		},
                       		{
                       			"SentenceWithUnderscoreInsteadOfPhrasalVerb": "They must ___ the problem before making a decision.",
                       			"CorrectPhrasalVerb": "get to grips with",
                       			"CorrectSentence": "They must get to grips with the problem before making a decision."
                       		}
                       	],
                       	"Header": {
                       		"Title": "Ćwiczenie na czasowniki frazowe - Poziom Zaawansowany",
                       		"TaskDescription": "Uzupełnij zdania odpowiednimi czasownikami frazowymi na poziomie zaawansowanym.",
                       		"Instruction": "Dobierz właściwy czasownik frazowy do każdego zdania.",
                       		"Example": "Przykład: Her rise to the challenging situation impressed everyone.",
                       		"SupportMaterial": "Wykorzystaj swoje umiejętności na poziomie zaawansowanym do poprawnego użycia czasowników frazowych w kontekście."
                       	}
                       }
                       """;

        var test = JsonSerializer.Deserialize<MissingPhrasalVerbOpen>(expected);

        string result = _service.FixJson(input);

        //Assert.Equal(expected, result);
        Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    }

    // [Fact]
    // public void FixJson_ShouldAddCommaInArrays()
    // {
    //     string input = @"{
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false,
    //             ""someCollection"": [
    //                 ""ok"",
    //                 ""notok"",
    //                 ""ok""
    //                 ""notok""
    //             ],
    //             ""value5"": 123,
    //             ""col2"": [
    //                 ""a""
    //                 ""b""
    //                 ""c""
    //             ]
    //         }
    //     }";
    //     string expected = @"{
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false,
    //             ""someCollection"": [
    //                 ""ok"",
    //                 ""notok"",
    //                 ""ok"",
    //                 ""notok""
    //             ],
    //             ""value5"": 123,
    //             ""col2"": [
    //                 ""a"",
    //                 ""b"",
    //                 ""c""
    //             ]
    //         }
    //     }";
    //
    //     string result = _service.FixJson(input);
    //
    //     //Assert.Equal(expected, result);
    //     Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }
    
    // [Fact]
    // public void FixJson_ShouldAddCommaInArray()
    // {
    //   string input = @"{
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false,
    //             ""someCollection"": [
    //                 ""ok""
    //                 ""notok""
    //             ]
    //         }
    //     }";
    //   string expected = @"{
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false,
    //             ""someCollection"": [
    //                 ""ok"",
    //                 ""notok""
    //             ]
    //         }
    //     }";
    //
    //   string result = _service.FixJson(input);
    //
    //   //Assert.Equal(expected, result);
    //   Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }

    // [Fact]
    // public void FixJson_ShouldAddCommaBetweenObjectsInArray()
    // {
    //     string input = @"{
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false,
    //             ""someCollection"": [
    //                 {
    //                     ""value1"": false
    //                 }
    //                 {
    //                     ""value1"": true
    //                 }
    //             ]
    //         }
    //     }";
    //     string expected = @"{
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false,
    //             ""someCollection"": [
    //                 {
    //                     ""value1"": false
    //                 },
    //                 {
    //                     ""value1"": true
    //                 }
    //             ]
    //         }
    //     }";
    //
    //     string result = _service.FixJson(input);
    //
    //     //Assert.Equal(expected, result);
    //     Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }

    //[Fact]
    // public void FixJson_ShouldAddCommaBetweenKeyValuesInNestedObject()
    // {
    //     string input = @"{
    //         ""value4"": {
    //             ""someValue"": 0//brak przecinka
    //             ""someValue2"": false,
    //             ""someCollection"": [
    //                 {
    //                     ""value1"": true
    //                 }
    //             ]
    //             ""someValue3"": 99//brak przecinka
    //             ""someValue4"": ""test""
    //         }
    //     }";
    //     string expected = @"{
    //         ""value4"": {
    //             ""someValue"": 0,
    //             ""someValue2"": false,
    //             ""someCollection"": [
    //                 {
    //                     ""value1"": true
    //                 }
    //             ],
    //             ""someValue3"": 99,
    //             ""someValue4"": ""test""
    //         }
    //     }";
    //
    //     string result = _service.FixJson(input);
    //
    //     //Assert.Equal(expected, result);
    //     Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
    // }

    //[Fact]
  // public void FixJson_ShouldCorrectlyFixComplexJson()
  // {
  //     var input = @"{
  //       ""Sentences"": [
  //         {
  //           ""Text"": ""The professor delivered a compelling lecture on quantum physics."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The professor gave a convincing talk on quantum mechanics."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The teacher presented a persuasive discourse on quantum science."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The lecturer provided a convincing presentation on atomic physics."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""Her exquisite taste in fashion is admired by many."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""Her refined sense of style is appreciated by numerous individuals."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""Her beautiful preference in clothing is liked by a lot of people."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""Her outstanding choice of garments is praised by several."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The entrepreneur established a successful startup in the tech industry."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The businessperson founded a prosperous venture in the technology sector."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The innovator set up a triumphing business in the technological field."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The mogul created a flourishing enterprise in the digital realm."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The artist's masterpiece evoked deep emotions in the viewers."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The painter's work of art stirred profound feelings in the spectators."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The creator's magnum opus aroused intense emotions in the audience."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The sculptor's creation triggered strong sentiments in the onlookers."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""His comprehensive knowledge of history impressed the historians."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""His extensive understanding of the past amazed the history experts."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""His detailed expertise in historical events astounded the history scholars."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""His thorough wisdom on the past fascinated the history buffs."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The soprano's performance enchanted the audience with her melodious voice."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The opera singer's show captivated the spectators with her tuneful vocal cords."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The vocalist's rendition mesmerized the viewers with her harmonic singing."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The diva's act charmed the onlookers with her musical tones."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The CEO's innovative strategies propelled the company to success."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The chief executive officer's original plans drove the corporation to prosperity."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The head executive's inventive approaches pushed the organization to triumph."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The leader's creative tactics moved the business to achievement."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The author's eloquent prose mesmerized readers worldwide."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The writer's articulate writing captivated readers across the globe."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The novelist's fluent words enchanted readers around the world."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The scribe's expressive language captured readers internationally."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""His philanthropic deeds have profoundly impacted society for the better."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""His charitable actions have significantly influenced society in a positive manner."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""His generous activities have deeply affected the community for good."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""His altruistic efforts have greatly changed the population beneficially."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The conductor's interpretation of the symphony was hailed as exceptional."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The maestro's rendering of the orchestral piece was praised as outstanding."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The music director's performance of the ensemble was acclaimed as extraordinary."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The leader's presentation of the musical work was recognized as remarkable."",
  //               ""Correct"": false
  //             }
  //           ]
  //         }
  //       ],
  //       ""Header"": {
  //         ""Title"": ""Ćwiczenie Parafrazowanie - Poziom Biegłości"",
  //         ""TaskDescription"": ""Wybierz poprawnie sparafrazowane zdanie zgodnie z oryginalnym zdaniem."",
  //         ""Instruction"": ""Wybierz jedną poprawną odpowiedź na każde pytanie."",
  //         ""Example"": ""His comprehensive knowledge of history impressed the historians. a) His extensive understanding of the past amazed the history experts. [Correct] b) His detailed expertise in historical events astounded the history scholars. c) His thorough wisdom on the past fascinated the history buffs.""
  //         ""SupportMaterial"": ""Paraphrasing - omówienie poszczególnych zdań i ich równoważnych wyrażeń w celu zrozumienia podobieństw w znaczeniu.""  
  //       }
  //     }";
  //     
  //     string expected = @"{
  //       ""Sentences"": [
  //         {
  //           ""Text"": ""The professor delivered a compelling lecture on quantum physics."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The professor gave a convincing talk on quantum mechanics."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The teacher presented a persuasive discourse on quantum science."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The lecturer provided a convincing presentation on atomic physics."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""Her exquisite taste in fashion is admired by many."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""Her refined sense of style is appreciated by numerous individuals."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""Her beautiful preference in clothing is liked by a lot of people."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""Her outstanding choice of garments is praised by several."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The entrepreneur established a successful startup in the tech industry."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The businessperson founded a prosperous venture in the technology sector."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The innovator set up a triumphing business in the technological field."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The mogul created a flourishing enterprise in the digital realm."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The artist's masterpiece evoked deep emotions in the viewers."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The painter's work of art stirred profound feelings in the spectators."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The creator's magnum opus aroused intense emotions in the audience."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The sculptor's creation triggered strong sentiments in the onlookers."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""His comprehensive knowledge of history impressed the historians."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""His extensive understanding of the past amazed the history experts."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""His detailed expertise in historical events astounded the history scholars."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""His thorough wisdom on the past fascinated the history buffs."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The soprano's performance enchanted the audience with her melodious voice."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The opera singer's show captivated the spectators with her tuneful vocal cords."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The vocalist's rendition mesmerized the viewers with her harmonic singing."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The diva's act charmed the onlookers with her musical tones."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The CEO's innovative strategies propelled the company to success."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The chief executive officer's original plans drove the corporation to prosperity."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The head executive's inventive approaches pushed the organization to triumph."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The leader's creative tactics moved the business to achievement."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The author's eloquent prose mesmerized readers worldwide."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The writer's articulate writing captivated readers across the globe."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The novelist's fluent words enchanted readers around the world."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The scribe's expressive language captured readers internationally."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""His philanthropic deeds have profoundly impacted society for the better."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""His charitable actions have significantly influenced society in a positive manner."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""His generous activities have deeply affected the community for good."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""His altruistic efforts have greatly changed the population beneficially."",
  //               ""Correct"": false
  //             }
  //           ]
  //         },
  //         {
  //           ""Text"": ""The conductor's interpretation of the symphony was hailed as exceptional."",
  //           ""Answers"": [
  //             {
  //               ""Text"": ""The maestro's rendering of the orchestral piece was praised as outstanding."",
  //               ""Correct"": true
  //             },
  //             {
  //               ""Text"": ""The music director's performance of the ensemble was acclaimed as extraordinary."",
  //               ""Correct"": false
  //             },
  //             {
  //               ""Text"": ""The leader's presentation of the musical work was recognized as remarkable."",
  //               ""Correct"": false
  //             }
  //           ]
  //         }
  //       ],
  //       ""Header"": {
  //         ""Title"": ""Ćwiczenie Parafrazowanie - Poziom Biegłości"",
  //         ""TaskDescription"": ""Wybierz poprawnie sparafrazowane zdanie zgodnie z oryginalnym zdaniem."",
  //         ""Instruction"": ""Wybierz jedną poprawną odpowiedź na każde pytanie."",
  //         ""Example"": ""His comprehensive knowledge of history impressed the historians. a) His extensive understanding of the past amazed the history experts. [Correct] b) His detailed expertise in historical events astounded the history scholars. c) His thorough wisdom on the past fascinated the history buffs."",
  //         ""SupportMaterial"": ""Paraphrasing - omówienie poszczególnych zdań i ich równoważnych wyrażeń w celu zrozumienia podobieństw w znaczeniu.""
  //       }
  //     }";
  //
  //     string result = _service.FixJson(input);
  //
  //     //Assert.Equal(expected, result);
  //     Assert.Equal(RemoveWhitespace(expected), RemoveWhitespace(result));
  // }

}
