using DictinaryPower.DAL.Context;
using DictinaryPower.DAL.Entitiyes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DictinaryPower.DAL.Repositories
{
    internal class PartOfSPeechRepository : DbRepository<PartOfSpeech>
    {
        public PartOfSPeechRepository(DictinaryDB db) : base(db) { }
    }
}
