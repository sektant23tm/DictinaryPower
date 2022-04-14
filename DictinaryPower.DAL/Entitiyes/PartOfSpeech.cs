﻿using DictinaryPower.DAL.Entitiyes.Base;
using System.Collections.Generic;

namespace DictinaryPower.DAL.Entitiyes
{
    public class PartOfSpeech : Entity
    {
        /// <summary>Наименование типа речи</summary>
        public virtual string Name { get; set; }

        /// <summary>Коллекция слов,имеющих данный тип речи</summary>
        public virtual ICollection<Word> Words { get; set; }
    }
}
