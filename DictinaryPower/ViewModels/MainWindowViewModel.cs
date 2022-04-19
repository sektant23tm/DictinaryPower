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
        private readonly IRepository<GlobalWord> _gWordRepository;
        IRepository<PartOfSpeech> _partOfSpeechRepository;
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

        #region GlobalWordCollection : IEnumerable<GlobalWord> - Коллекция слов GWord из БД
        /// <summary>Коллекция слов GWord из БД</summary>
        private IEnumerable<GlobalWord> _GlobalWordCollection;
        /// <summary>Коллекция слов GWord из БД</summary>
        public IEnumerable<GlobalWord> GlobalWordCollection
        {
            get => _GlobalWordCollection;
            set
            {
                if (!Set(ref _GlobalWordCollection, value)) return;
                _GlobalWordViewSource.Source = value ?? null;
                OnPropertyChanged(nameof(GlobalWordViewSource));
            }
        }
        #endregion

        #region PartOfSpeechCollection : IEnumerable<PartOfSpeech> - Коллекция частей речи из БД
        /// <summary>Коллекция частей речи из БД</summary>
        private IEnumerable<PartOfSpeech> _PartOfSpeechCollection;
        /// <summary>Коллекция частей речи из БД</summary>
        public IEnumerable<PartOfSpeech> PartOfSpeechCollection
        {
            get => _PartOfSpeechCollection;
            set => Set(ref _PartOfSpeechCollection, value);
        }
        #endregion

        #region SelectedGlobalWord : GlobalWord - Выбранный в основном листБоксе GlobalWord
        /// <summary>Выбранный в основном листБоксе GlobalWord</summary>
        private GlobalWord _SelectedGlobalWord;
        /// <summary>Выбранный в основном листБоксе GlobalWord</summary>
        public GlobalWord SelectedGlobalWord
        {
            get
            {
                if (_SelectedGlobalWord is null)
                    return null;

                if (_SelectedGlobalWord.Words is null)
                    _SelectedGlobalWord = _gWordRepository.Get(_SelectedGlobalWord.Id);

                return _SelectedGlobalWord;
            }
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

        public MainWindowViewModel()
        {
            if (App.IsDesignMode == false)
                throw new InvalidOperationException("Данный конструктор не предназначен для работы в дизанере");

            var testData = new DebugRepositoryGlobalWordServvice();
            GlobalWordCollection = testData.GWords;
            PartOfSpeechCollection = testData.PartOfSpeeches;
        }


        public MainWindowViewModel(IRepository<GlobalWord> gWordRepository, IRepository<PartOfSpeech> partOfSpeechRepository)
        {
            #region Инициализация команд
            RemoveGlobalWordCommand = new LambdaCommand(OnRemoveGlobalWordCommandExecuted, CanRemoveGlobalWordCommandExecute);
            #endregion

            #region Инициализация сервисов
            _gWordRepository = gWordRepository;
            _partOfSpeechRepository = partOfSpeechRepository;
            #endregion

            #region Инициализация свойств
            GlobalWordCollection = _gWordRepository.Items.ToArray();
            PartOfSpeechCollection = _partOfSpeechRepository.Items.ToArray();
            #endregion

            #region Инициализация событий
            _GlobalWordViewSource.Filter += OnGlobalWordFiltered;
            #endregion
        }
    }
}
