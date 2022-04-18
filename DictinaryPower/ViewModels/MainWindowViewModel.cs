using DictinaryPower.DAL.Entitiyes;
using DictinaryPower.DAL.Repositories.Interfaces;
using DictinaryPower.Infrastructure.Commands;
using DictinaryPower.Infrastructure.Debug;
using DictinaryPower.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
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
            set
            {
                if (!Set(ref _DebugGlobalWordCollection, value)) return;
                _GlobalWordViewSource.Source = value ?? null;
                OnPropertyChanged(nameof(GlobalWordViewSource));
            }
        }
        #endregion

        #region DebugPartOfSpeechCollection : Ienumerable<partOfSpeech> - Коллекция частей речи , чтобы успешно дебажить визуальную часть
        /// <summary>Коллекция частей речи , чтобы успешно дебажить визуальную часть</summary>
        private IEnumerable<PartOfSpeech> _DebugPartOfSpeechCollection;
        /// <summary>Коллекция частей речи , чтобы успешно дебажить визуальную часть</summary>
        public IEnumerable<PartOfSpeech> DebugPartOfSpeechCollection
        {
            get => _DebugPartOfSpeechCollection;
            set => Set(ref _DebugPartOfSpeechCollection, value);
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

        #region TextSearch : string - Строка поиска внутри ListBox
        /// <summary>Строка поиска внутри ListBox</summary>
        private string _TextSearch;
        /// <summary>Строка поиска внутри ListBox</summary>
        public string TextSearch
        {
            get => _TextSearch;
            set
            {
                if (!Set(ref _TextSearch, value)) return;
                _GlobalWordViewSource.View.Refresh();
            }
        }
        #endregion

        #region GlobalWordFilter
        private readonly CollectionViewSource _GlobalWordViewSource = new CollectionViewSource();
        public ICollectionView GlobalWordViewSource => _GlobalWordViewSource?.View;
        private void OnGlobalWordFiltered(object sender, FilterEventArgs e)
        {
            if (!(e.Item is GlobalWord gWord)) return;
            if (string.IsNullOrWhiteSpace(TextSearch)) return;

            if (gWord.Value.Contains(TextSearch, StringComparison.OrdinalIgnoreCase)) return;
            e.Accepted = false;
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

        IRepository<GlobalWord> _gWordRepository;

        public MainWindowViewModel(IRepository<GlobalWord> gWordRepository)
        {
            #region Инициализация команд
            RemoveGlobalWordCommand = new LambdaCommand(OnRemoveGlobalWordCommandExecuted, CanRemoveGlobalWordCommandExecute);
            #endregion

            #region Инициализация сервисов
            _debugGlobalWordService = new DebugRepositoryGlobalWordServvice();
            DebugGlobalWordCollection = _debugGlobalWordService.Items;
            DebugPartOfSpeechCollection = _debugGlobalWordService.PartOfSpeeches;
            SelectedGlobalWord = DebugGlobalWordCollection.ToArray()[0];
            #endregion

            #region Инициализация событий
            _GlobalWordViewSource.Filter += OnGlobalWordFiltered;
            _gWordRepository = gWordRepository;

            var words = gWordRepository.Items.ToArray();

            var word = gWordRepository.Get(1);

            #endregion
        }


    }
}
