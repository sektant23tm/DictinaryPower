using DictinaryPower.Data;
using DictinaryPower.Services;
using DictinaryPower.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace DictinaryPower
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static bool IsDesignMode { get; private set; } = true;

        private static IHost __host;
        //При обращении __host если == null ,то вроводим инициализацию
        public static IHost Host => __host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        /// <summary>
        /// Возможность извлечь из нашего приложения все необходимые сервисы
        /// </summary>
        public static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddViewModels()
            .AddServices()
            .AddDatabase(host.Configuration.GetSection("Database"));

        protected async override void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;
            var host = Host;

            //Инициализация БД и заполнение тестовыми даными
            using (var scope = Services.CreateScope())
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();

                base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            using (Host)
                await Host.StopAsync();
        }
    }
}
