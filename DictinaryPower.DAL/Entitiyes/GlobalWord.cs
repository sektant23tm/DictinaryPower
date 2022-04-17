using DictinaryPower.DAL.Entitiyes.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DictinaryPower.DAL.Entitiyes
{
    public class GlobalWord : Entity
    {
        /// <summary>Глобальное слово</summary>
        [Required]
        public virtual string Value { get; set; }

        /// <summary>Транскрипция</summary>
        public virtual ICollection<Word> Words { get; set; }
    }
}
