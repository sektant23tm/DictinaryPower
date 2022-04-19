using DictinaryPower.DAL.Context;
using DictinaryPower.DAL.Entitiyes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DictinaryPower.DAL.Repositories
{
    internal class GWordRepository : DbRepository<GlobalWord>
    {
        private readonly DbSet<GlobalWord> _set;
        public GWordRepository(DictinaryDB db) : base(db) => _set = db.Set<GlobalWord>();

        public override GlobalWord Get(int id) => _set
            .Include(w => w.Words)
            .ThenInclude(p => p.PartSpeech)
            .Include(w => w.Words)
            .ThenInclude(t => t.Translates)
            .ThenInclude(e => e.ExampleSentences).SingleOrDefault(n => n.Id == id);
    }
}
