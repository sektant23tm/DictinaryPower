using Microsoft.Extensions.DependencyInjection;

namespace DictinaryPower.ViewModels
{
    internal class ViewModelLocator
    {
        //Обращаемся к хосту и просим выдать нам ViewModel из сервисов
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
