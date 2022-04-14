using Microsoft.Extensions.Hosting;
using System;

namespace DictinaryPower
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        /// <summary>
        /// Метод генерирует построитель Хоста и вызываем в нём метод конфигурации сервисов App.ConfigureServices хоста
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(App.ConfigureServices);
    }
}
