using DictinaryPower.DAL.Entitiyes;
using DictinaryPower.Infrastructure.Commands;
using DictinaryPower.Infrastructure.Debug;
using DictinaryPower.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace DictinaryPower.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Сервисы
        private readonly DebugRepositoryGlobalWordServvice _debugGlobalWordService;
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

        #region DebugGlobalWordCollection : IEnumerable<GlobalWord> - Коллекция слов-примернов чтобы успешно дебажить визуальную часть
        /// <summary>Коллекция слов-примернов чтобы успешно дебажить визуальную часть</summary>
        private IEnumerable<GlobalWord> _DebugGlobalWordCollection;
        /// <summary>Коллекция слов-примернов чтобы успешно дебажить визуальную часть</summary>
        public IEnumerable<GlobalWord> DebugGlobalWordCollection
        {
            get => _DebugGlobalWordCollection;
            set => Set(ref _DebugGlobalWordCollection, value);
        }
        #endregion

        #region SelectedGlobalWord : GlobalWord - Выбранный в основном листБоксе GlobalWord
        /// <summary>Выбранный в основном листБоксе GlobalWord</summary>
        private GlobalWord _SelectedGlobalWord;
        /// <summary>Выбранный в основном листБоксе GlobalWord</summary>
        public GlobalWord SelectedGlobalWord
        {
            get => _SelectedGlobalWord;
            set => Set(ref _SelectedGlobalWord, value);
        }
        #endregion

        #endregion

        #region Команды

        #region Command : RemoveGlobalWordCommand - Удаление выделенного глобального слова
        /// <summary>Удаление выделенного глобального слова</summary>
        public ICommand RemoveGlobalWordCommand { get; }
        /// <summary>Проверка возможности выполнения команды - Удаление выделенного глобального слова</summary>
        public bool CanRemoveGlobalWordCommandExecute(object p) => SelectedGlobalWord is not null;
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
            _debugGlobalWordService = new DebugRepositoryGlobalWordServvice();
            DebugGlobalWordCollection = _debugGlobalWordService.Items;
            SelectedGlobalWord = DebugGlobalWordCollection.ToArray()[0];
            #endregion
        }


    }
}
