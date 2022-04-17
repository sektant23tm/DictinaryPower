using DictinaryPower.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictinaryPower.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<DictinaryDB>(opt =>
            {
                var type = configuration["Type"];

                if (type == null) throw new InvalidOperationException("Не определён тип БД");
                if (type != "MSSQL") throw new InvalidOperationException($"Тип подключения {type} не поддерживается");

                opt.UseSqlServer(configuration.GetConnectionString(type));
            });
    }
}
