using DictinaryPower.DAL.Entitiyes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictinaryPower.DAL.Context
{
    public class DictinaryDB : DbContext
    {
        public DbSet<GlobalWord> GlobalWords { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Translate> Translates { get; set; }
        public DbSet<PartOfSpeech> PartOfSpeeches { get; set; }
        public DbSet<ExampleSentence> ExampleSentences { get; set; }

        public DictinaryDB(DbContextOptions<DictinaryDB> options) : base(options) { }
    }
}
