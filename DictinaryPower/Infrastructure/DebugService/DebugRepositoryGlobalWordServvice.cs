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
            #region PathOfSpeech
            PartOfSpeech[] _pathOfSpeeches;

            _pathOfSpeeches = new PartOfSpeech[9];
            _pathOfSpeeches[0] = new PartOfSpeech { Name = "Noun" };          // Существительное
            _pathOfSpeeches[1] = new PartOfSpeech { Name = "Verb" };          // Глагол
            _pathOfSpeeches[2] = new PartOfSpeech { Name = "Adjective" };    // Прилагательное
            _pathOfSpeeches[3] = new PartOfSpeech { Name = "Pronoun" };      // Местоимение
            _pathOfSpeeches[4] = new PartOfSpeech { Name = "Numeral" };      // Чистительное
            _pathOfSpeeches[5] = new PartOfSpeech { Name = "Adverb" };       // Наречие
            _pathOfSpeeches[6] = new PartOfSpeech { Name = "Preposition" };  // Предлог
            _pathOfSpeeches[7] = new PartOfSpeech { Name = "Conjunction" };  // Союз
            _pathOfSpeeches[8] = new PartOfSpeech { Name = "Particle" };     // Частица


            #endregion

            #region GlobalWords
            GlobalWord[] _globalWords;

            _globalWords = new GlobalWord[6];
            _globalWords[0] = new GlobalWord
            {
                Value = "do",
                Transcription = "duː"
            };
            _globalWords[1] = new GlobalWord
            {
                Value = "engine",
                Transcription = "ˈendʒɪn"
            };
            _globalWords[2] = new GlobalWord
            {
                Value = "current",
                Transcription = "ˈkɜːrənt"
            };
            _globalWords[3] = new GlobalWord
            {
                Value = "first",
                Transcription = "fɜːrst"
            };
            _globalWords[4] = new GlobalWord
            {
                Value = "kiss",
                Transcription = "kɪs"
            };
            _globalWords[5] = new GlobalWord
            {
                Value = "Punishment"
            };

            #endregion

            #region Words
            Word[] _words;

            _words = new Word[10];
            _words[0] = new Word
            {
                Value = "do",
                GlobalWord = _globalWords[0],
                Forms = "did / done / doing / does",
                PartSpeech = _pathOfSpeeches[1]
            };
            _words[1] = new Word
            {
                Value = "engine",
                GlobalWord = _globalWords[1],
                Forms = "engines",
                PartSpeech = _pathOfSpeeches[0]
            };
            _words[2] = new Word
            {
                Value = "current",
                GlobalWord = _globalWords[2],
                PartSpeech = _pathOfSpeeches[2]
            };
            _words[3] = new Word
            {
                Value = "current",
                GlobalWord = _globalWords[2],
                Forms = "currents",
                PartSpeech = _pathOfSpeeches[0]
            };
            _words[4] = new Word
            {
                Value = "first",
                GlobalWord = _globalWords[3],
                PartSpeech = _pathOfSpeeches[2]
            };
            _words[5] = new Word
            {
                Value = "first",
                GlobalWord = _globalWords[3],
                PartSpeech = _pathOfSpeeches[5]
            };
            _words[6] = new Word
            {
                Value = "kiss",
                GlobalWord = _globalWords[4],
                PartSpeech = _pathOfSpeeches[0],
                Forms = "kisses"
            };
            _words[7] = new Word
            {
                Value = "kiss",
                GlobalWord = _globalWords[4],
                PartSpeech = _pathOfSpeeches[1],
                Forms = "kissed / kissed / kissing / kisses"
            };
            _words[8] = new Word
            {
                Value = "Punishment",
                GlobalWord = _globalWords[5],
                PartSpeech = _pathOfSpeeches[0],
                Forms = "punishments",
                Transcription = "ˈpʌnɪʃmənt"
            };
            _words[9] = new Word
            {
                Value = "punish",
                GlobalWord = _globalWords[5],
                PartSpeech = _pathOfSpeeches[1],
                Forms = "punishments",
                Transcription = "punished / punished / punishing / punishes"
            };


            #endregion

            #region Translate
            Translate[] _translates;

            _translates = new Translate[13];
            _translates[0] = new Translate
            {
                Value = "делать",
                Word = _words[0]
            };
            _translates[1] = new Translate
            {
                Value = "cделать",
                Word = _words[0]
            };
            _translates[2] = new Translate
            {
                Value = "двигатель, движок",
                Word = _words[1]
            };
            _translates[3] = new Translate
            {
                Value = "машина",
                Word = _words[1]
            };
            _translates[4] = new Translate
            {
                Value = "первый",
                Word = _words[4]
            };
            _translates[5] = new Translate
            {
                Value = "сначала , поначалу , сперва",
                Word = _words[5]
            };
            _translates[6] = new Translate
            {
                Value = "текущий",
                Word = _words[2]
            };
            _translates[7] = new Translate
            {
                Value = "нынешний",
                Word = _words[2]
            };
            _translates[8] = new Translate
            {
                Value = "течение , поток , ход",
                Word = _words[3]
            };
            _translates[9] = new Translate
            {
                Value = "поцелуй",
                Word = _words[6]

            };
            _translates[10] = new Translate
            {
                Value = "целовать",
                Word = _words[7]
            };
            _translates[11] = new Translate
            {
                Value = "наказание , взыскание",
                Word = _words[8]
            };
            _translates[12] = new Translate
            {
                Value = "наказать  наказывать , карать",
                Word = _words[9]
            };

            #endregion

            #region ExampleSentences
            ExampleSentence[] _examples;

            _examples = new ExampleSentence[15];
            _examples[0] = new ExampleSentence
            {
                EnglishSentence = "We don't do that.",
                RussianSentence = "Мы этого не делаем.",
                Translate = _translates[0]
            };
            _examples[1] = new ExampleSentence
            {
                EnglishSentence = "Yes, we'll do that.",
                RussianSentence = "Да, мы так и сделаем.",
                Translate = _translates[1]
            };
            _examples[2] = new ExampleSentence
            {
                EnglishSentence = "The engine missed.",
                RussianSentence = "Двигатель заглох.",
                Translate = _translates[2]
            };
            _examples[3] = new ExampleSentence
            {
                EnglishSentence = "The engine has burned out.",
                RussianSentence = "Двигатель перегрелся.",
                Translate = _translates[2]
            };
            _examples[4] = new ExampleSentence
            {
                EnglishSentence = "Now this is an engine component.",
                RussianSentence = "Это - деталь машины.",
                Translate = _translates[3]
            };
            _examples[5] = new ExampleSentence
            {
                EnglishSentence = "That is my first wish.",
                RussianSentence = "Это мое первое желание.",
                Translate = _translates[4]
            };
            _examples[6] = new ExampleSentence
            {
                EnglishSentence = "I have to pay him first.",
                RussianSentence = "Сперва я должен ему заплатить.",
                Translate = _translates[5]
            };
            _examples[7] = new ExampleSentence
            {
                EnglishSentence = "I'm worried about the current political situation.",
                RussianSentence = "Меня беспокоит текущая политическая ситуация.",
                Translate = _translates[6]
            };
            _examples[8] = new ExampleSentence
            {
                EnglishSentence = "Who is your current employer?",
                RussianSentence = "Кто ваш нынешний работодатель?",
                Translate = _translates[7]
            };
            _examples[9] = new ExampleSentence
            {
                EnglishSentence = "Do you remember your first kiss?",
                RussianSentence = "Помните ли вы свой первый поцелуй?",
                Translate = _translates[9]
            };
            _examples[10] = new ExampleSentence
            {
                EnglishSentence = "Kiss my ass!",
                RussianSentence = "Поцелуй меня в задницу!",
                Translate = _translates[10]
            };
            _examples[11] = new ExampleSentence
            {
                EnglishSentence = "I was sent to bed as a punishment.",
                RussianSentence = "В качестве наказания, меня отправили спать.",
                Translate = _translates[11]
            };
            _examples[12] = new ExampleSentence
            {
                EnglishSentence = "The Court decides what punishment to impose.",
                RussianSentence = "Суд решает, какое наказание наложить.",
                Translate = _translates[11]
            };
            _examples[13] = new ExampleSentence
            {
                EnglishSentence = "She was punished for lying.",
                RussianSentence = "Она была наказана за ложь.",
                Translate = _translates[12]
            };
            _examples[14] = new ExampleSentence
            {
                EnglishSentence = "You can't punish a man for speaking the truth.",
                RussianSentence = "Вы не можете наказать человека за то, что он говорит правду.",
                Translate = _translates[12]
            };


            #endregion


            Items = _globalWords.AsEnumerable();
        }
    }
}
