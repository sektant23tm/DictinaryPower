using System.ComponentModel.DataAnnotations;

namespace DictinaryPower.DAL.Entitiyes.Base
{
    public abstract class Entity
    {
        /// <summary>Int32 айди сущности</summary>
        [Required]
        public int Id { get; set; }
    }
}
