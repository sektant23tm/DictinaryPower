using DictinaryPower.DAL.Entitiyes.Base;
using System.ComponentModel.DataAnnotations;

namespace DictinaryPower.DAL.Entitiyes
{
    public class ExampleSentence : Entity
    {
        /// <summary>Перевод,которому принадлежит данное предложение-пример</summary>
        [Required]
        public virtual Translate Translate { get; set; }

        /// <summary>Предложение-пример на английском</summary>
        [Required]
        public virtual string EnglishSentence { get; set; }

        /// <summary>Предложение-пример на русском</summary>
        [Required]
        public virtual string RussianSentence { get; set; }
    }
}
