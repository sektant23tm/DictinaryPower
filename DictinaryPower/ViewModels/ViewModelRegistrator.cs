using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictinaryPower.ViewModels
{
    internal static class ViewModelRegistrator
    {
        /*
            Transient: при каждом обращении к сервису создается новый объект сервиса. 
                В течение одного запроса может быть несколько обращений к сервису, соответственно при каждом обращении будет создаваться новый объект. 
                Подобная модель жизненного цикла наиболее подходит для легковесных сервисов, которые не хранят данных о состоянии

            Scoped: для каждого запроса создается свой объект сервиса. 
                То есть если в течение одного запроса есть несколько обращений к одному сервису, то при всех этих обращениях будет использоваться один и тот же объект сервиса.

            Singleton: объект сервиса создается при первом обращении к нему, все последующие запросы используют один и тот же ранее созданный объект сервиса
        */

        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;
    }
}
