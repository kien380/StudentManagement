using System.Collections.ObjectModel;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Enums;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class ChooseClassPageViewModel : ViewModelBase
    {
        #region private properties
        private ObservableCollection<Class> _classes;
        #endregion

        #region public properties
        public ObservableCollection<Class> Classes
        {
            get => _classes;
            set => SetProperty(ref _classes, value);
        }
        #endregion

        public ChooseClassPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Set values
            PageTitle = "Chọn lớp";
            Classes = new ObservableCollection<Class> { new Class(), new Class(), new Class() };
        }

        #region
        public void ClassesItemTapped(Class _class)
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.DetailClassPageType.ToString(), DetailClassPageType.ClassAcceptStudent }
            };
            NavigationService.NavigateAsync(PageManager.DetailClassPage, navParam);
        }
        #endregion
    }
}
