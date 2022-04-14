using DictinaryPower.DAL.Entitiyes.Base;
using System.Collections.Generic;

namespace DictinaryPower.DAL.Entitiyes
{
    public class Translate : Entity
    {
        /// <summary>Перевоз слова</summary>
        public virtual string Value { get; set; }

        /// <summary>Англисйкое слово,которому принадлежит перевод</summary>
        public virtual Word Word { get; set; }

        /// <summary>Набор предложений-примеров ,принадлежащих переводу</summary>
        public virtual ICollection<ExampleSentence> ExampleSentences { get; set; }
    }
}
