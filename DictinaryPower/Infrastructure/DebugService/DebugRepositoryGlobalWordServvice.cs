using DictinaryPower.DAL.Entitiyes;
using System.Collections.Generic;
using System.Linq;

namespace DictinaryPower.Infrastructure.Debug
{
    internal class DebugRepositoryGlobalWordServvice
    {
        public IEnumerable<GlobalWord> GWords { get; }

        public IEnumerable<PartOfSpeech> PartOfSpeeches { get; }

        public DebugRepositoryGlobalWordServvice()
        {
            PartOfSpeeches = new List<PartOfSpeech>()
            {
                 new PartOfSpeech { Name = "Noun" },
                 new PartOfSpeech { Name = "Verb" },
                 new PartOfSpeech { Name = "Adjective" },
                 new PartOfSpeech { Name = "Pronoun" },
                 new PartOfSpeech { Name = "Numeral" },
                 new PartOfSpeech { Name = "Adverb" },
                 new PartOfSpeech { Name = "Preposition" },
                 new PartOfSpeech { Name = "Conjunction" },
                 new PartOfSpeech { Name = "Particle" }
            };

            GWords = new List<GlobalWord>()
            {
                new GlobalWord
                {
                    Value = "first",
                    Words= new List<Word>()
                    {
                        new Word
                        {
                            Value = "first",
                            PartSpeech = PartOfSpeeches.ToArray()[2],
                            Translates = new List<Translate>()
                            {
                                new Translate
                                {
                                     Value = "текущий",

                                     ExampleSentences = new List<ExampleSentence>()
                                     {
                                         new ExampleSentence
                                         {
                                             EnglishSentence = "I'm worried about the current political situation.",
                                             RussianSentence = "Меня беспокоит текущая политическая ситуация."
                                         },
                                         new ExampleSentence
                                         {
                                             EnglishSentence = "Do you remember your first kiss?",
                                             RussianSentence = "Помните ли вы свой первый поцелуй?"
                                         }
                                     }
                                },
                                new Translate
                                {
                                     Value = "нынешний" ,

                                     ExampleSentences = new List<ExampleSentence>()
                                     {
                                         new ExampleSentence
                                         {
                                             EnglishSentence = "Who is your current employer?",
                                             RussianSentence = "Кто ваш нынешний работодатель?"
                                         }
                                     }
                                }
                            }
                        },
                        new Word
                        {
                            Value = "first",
                            PartSpeech = PartOfSpeeches.ToArray()[5],
                            Translates = new List<Translate>()
                            {
                                new Translate
                                {
                                     Value = "течение , поток , ход"
                                }
                            }
                            
                        }
                    }
                },
                new GlobalWord
                {
                    Value = "do",
                    Words = new List<Word>()
                    {
                        new Word
                        {
                              Value = "do",
                              Forms = "did / done / doing / does" ,
                              Transcription = "ˈkɜːrənt",
                              PartSpeech = PartOfSpeeches.ToArray()[1],
                              Translates = new List<Translate>()
                              {
                                  new Translate
                                  {
                                        Value = "делать",
                                        ExampleSentences = new List<ExampleSentence>()
                                        {
                                            new ExampleSentence
                                            {
                                                EnglishSentence = "We don't do that.",
                                                RussianSentence= "Мы этого не делаем."
                                            }
                                        }
                                  }
                              }
                        }
                    }
                }
            };

        }
    }
}
