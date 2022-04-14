using DictinaryPower.Infrastructure.Commands;
using DictinaryPower.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DictinaryPower.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Сервисы

        #endregion

        #region Константы

        #endregion

        #region Свойства

        #region Title : string - Заголовок окна
        /// <summary>Заголовок окна</summary>
        private string _Title = "Очередная новая программа";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #endregion

        #region Команды

        #region Command : RemoveGlobalWordCommand - Удаление выделенного глобального слова
        /// <summary>Удаление выделенного глобального слова</summary>
        public ICommand RemoveGlobalWordCommand { get; }
        /// <summary>Проверка возможности выполнения команды - Удаление выделенного глобального слова</summary>
        public bool CanRemoveGlobalWordCommandExecute(object p) => false;
        /// <summary>Логика выполнения - Удаление выделенного глобального слова</summary>
        private void OnRemoveGlobalWordCommandExecuted(object p)
        {

        }
        #endregion

        #endregion

        #region Сервисы

        #endregion

        public MainWindowViewModel()
        {
            #region Инициализация команд
            RemoveGlobalWordCommand = new LambdaCommand(OnRemoveGlobalWordCommandExecuted, CanRemoveGlobalWordCommandExecute);
            #endregion

            #region Инициализация сервисов

            #endregion
        }


    }
}
