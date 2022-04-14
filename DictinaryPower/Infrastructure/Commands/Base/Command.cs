using System;
using System.Windows.Input;

namespace DictinaryPower.Infrastructure.Commands.Base
{
    abstract internal class Command : ICommand
    {
        /// <summary>
        /// Основное событие интерфейса ICommand . Генерируется в тот момент,когда CanExecute переходит из одного состояния в другое
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            //Передаём управление событием классу CommandManager

            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #region Executable : bool - Дополнительное свойство,позволяющее либо включать либо выключать команду
        /// <summary>Дополнительное свойство,позволяющее либо включать либо выключать команду</summary>
        private bool _executable = true;
        /// <summary>Дополнительное свойство,позволяющее либо включать либо выключать команду</summary>
        public bool Executable
        {
            get => _executable;
            set
            {
                if (_executable == value) return;
                _executable = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }
        #endregion

        bool ICommand.CanExecute(object parameter) => _executable && CanExecute(parameter);
        void ICommand.Execute(object parameter)
        {
            if (CanExecute(parameter))
                Execute(parameter);
        }

        /// <summary>
        /// Проверяет возможность выполнения функции
        /// </summary>
        /// <returns></returns>
        protected virtual bool CanExecute(object p) => true;
        /// <summary>
        /// Выполнение основной логики команды
        /// </summary>
        protected abstract void Execute(object p);
    }
}
