using DictinaryPower.DAL.Entitiyes.Base;
using System.Collections.Generic;

namespace DictinaryPower.DAL.Entitiyes
{
    public class GlobalWord : Entity
    {
        /// <summary>Глобальное слово</summary>
        public virtual string Value { get; set; }

        /// <summary>Транскрипция</summary>
        public virtual string Transcription { get; set; }

        /// <summary>Транскрипция</summary>
        public virtual ICollection<Word> Words { get; set; }
    }
}
