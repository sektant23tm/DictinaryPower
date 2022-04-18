using DictinaryPower.DAL.Entitiyes;
using DictinaryPower.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DictinaryPower.DAL.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoryInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<PartOfSpeech>, PartOfSPeechRepository>()
            .AddTransient<IRepository<GlobalWord>, GWordRepository>()
            .AddTransient<IRepository<Word>, DbRepository<Word>>()
            .AddTransient<IRepository<Translate>, DbRepository<Translate>>()
            .AddTransient<IRepository<ExampleSentence>, DbRepository<ExampleSentence>>()
            ;
    }
}
