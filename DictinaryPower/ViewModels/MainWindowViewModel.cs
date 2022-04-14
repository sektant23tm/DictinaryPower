using DictinaryPower.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

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

        #endregion

        #region Сервисы

        #endregion

        public MainWindowViewModel()
        {
            #region Инициализация команд

            #endregion

            #region Инициализация сервисов

            #endregion
        }
    }
}
