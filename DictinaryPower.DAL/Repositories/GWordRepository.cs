using DictinaryPower.DAL.Context;
using DictinaryPower.DAL.Entitiyes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DictinaryPower.DAL.Repositories
{
    internal class GWordRepository : DbRepository<GlobalWord>
    {
        public GWordRepository(DictinaryDB db) : base(db) { }

        //public override IQueryable<GlobalWord> Items => base.Items.Include(i => i.Words);

        public override GlobalWord Get(int id) => Items
            .Include(w => w.Words)
            .ThenInclude(p => p.PartSpeech)
            .Include(w => w.Words)
            .ThenInclude(t => t.Translates)
            .ThenInclude(e => e.ExampleSentences).SingleOrDefault(n => n.Id == id);
    }
}
