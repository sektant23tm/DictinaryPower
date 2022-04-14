using DictinaryPower.DAL.Entitiyes;
using System.Collections.Generic;
using System.Linq;

namespace DictinaryPower.Infrastructure.Debug
{
    internal class DebugRepositoryGlobalWordServvice
    {
        public IEnumerable<GlobalWord> Items { get; }

        public DebugRepositoryGlobalWordServvice()
        {
            Items = new List<GlobalWord>()
            {
                new GlobalWord
                {
                    Value = "do",
                    Transcription = "duː",
                    Words = new List<Word>()
                    {
                        new Word
                        {
                              Value = "do",
                              Forms = "did / done / doing / does" ,
                              PartSpeech = new PartOfSpeech { Name = "Verb" },
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
                },
                new GlobalWord
                {
                    Value = "first",
                    Transcription = "fɜːrst",
                    Words= new List<Word>()
                    {
                        new Word
                        {
                            Value = "first",
                            PartSpeech = new PartOfSpeech { Name = "Adjective" },
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
                            PartSpeech = new PartOfSpeech { Name = "Adverb" },
                            Translates = new List<Translate>()
                            {
                                new Translate
                                {
                                     Value = "течение , поток , ход"
                                }
                            }
                            
                        }
                    }
                }
            };
        }
    }
}
