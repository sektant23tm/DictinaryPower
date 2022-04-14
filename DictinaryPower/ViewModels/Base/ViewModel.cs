using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DictinaryPower.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Запускает событие 
        /// </summary>
        /// <param name="PropertyName">Самостоятельно определится компилятором за счёт атрибута [Имя вызывающего метода или свойства]</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        /// <summary>
        /// Задача метода обновлять значение свойства , для которого определено поле , в котором это свойство хранит свои данные
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Ссылка на поле свойства</param>
        /// <param name="value">Новое значение , которое мы хотим установить</param>
        /// <param name="PropertyName">Самостоятельно определится компилятором за счёт атрибута [Имя вызывающего метода или свойства]</param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
