using DictinaryPower.DAL.Entitiyes.Base;
using System.Collections.Generic;

namespace DictinaryPower.DAL.Entitiyes
{
    public class Word : Entity
    {
        /// <summary>Глобальное слово ,которому принадлежит данное слово</summary>
        public virtual GlobalWord GlobalWord { get; set; }

        /// <summary>Слово на английском языке</summary>
        public virtual string Value { get; set; }

        /// <summary>Часть речи</summary>
        public virtual PartOfSpeech PartSpeech { get; set; }

        /// <summary>Транскрипция</summary>
        public virtual string Transcription { get; set; }

        /// <summary>Возможные формы слова</summary>
        public virtual string Forms { get; set; }

        /// <summary>Коллекция переводов текущего слова в текущей части речи</summary>
        public virtual ICollection<Translate> Translates { get; set; }
    }
}
