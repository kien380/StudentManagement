using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Enums;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class ListClassesPageViewModel : ViewModelBase
    {
        #region private properties

        private bool _showSearchBox;
        private string _searchText;
        private ObservableCollection<Class> _classes;

        #endregion

        #region public properties
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public bool ShowSearchBox
        {
            get => _showSearchBox;
            set => SetProperty(ref _showSearchBox, value);
        }

        public ObservableCollection<Class> Classes
        {
            get => _classes;
            set => SetProperty(ref _classes, value);
        }

        // Commands
        public ICommand SearchToolbarItemsCommand { get; set; }
        public ICommand SearchIconCommand { get; set; }
        #endregion

        public ListClassesPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Set values
            PageTitle = "Danh sách các lớp";
            ShowSearchBox = false;
            Classes = new ObservableCollection<Class>{new Class(), new Class(), new Class()};

            // Commands
            SearchToolbarItemsCommand = new DelegateCommand(SearchToolbarItemsExecute);
            SearchIconCommand = new DelegateCommand(SearchIconExecute);
        }

        #region Methods

        private void SearchToolbarItemsExecute()
        {
            ShowSearchBox = !ShowSearchBox;
        }

        private void SearchIconExecute()
        {
            Dialog.DisplayAlertAsync("Search", "Search clicked", "OK");
        }

        public void ClassesItemTapped(Class _class)
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.DetailClassPageType.ToString(), DetailClassPageType.ClassInfo }
            };
            NavigationService.NavigateAsync(PageManager.DetailClassPage, navParam);
        }
        #endregion
    }
}
