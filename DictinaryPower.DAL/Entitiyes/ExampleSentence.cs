using DictinaryPower.DAL.Entitiyes.Base;

namespace DictinaryPower.DAL.Entitiyes
{
    public class ExampleSentence : Entity
    {
        /// <summary>Перевод,которому принадлежит данное предложение-пример</summary>
        public virtual Translate Translate { get; set; }

        /// <summary>Предложение-пример на английском</summary>
        public virtual string EnglishSentence { get; set; }

        /// <summary>Предложение-пример на русском</summary>
        public virtual string RussianSentence { get; set; }
    }
}
