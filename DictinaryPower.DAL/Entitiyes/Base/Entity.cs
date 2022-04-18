using DictinaryPower.DAL.Interfaces.Entitiyes.Base;
using System.ComponentModel.DataAnnotations;

namespace DictinaryPower.DAL.Entitiyes.Base
{
    public abstract class Entity : IEntity
    {
        /// <summary>Int32 айди сущности</summary>
        [Required]
        public int Id { get; set; }
    }
}
