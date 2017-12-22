using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Enums;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;
using StudentManagement.Views.Popups;

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
            LoadClass();
        }

        private async void LoadClass()
        {
            await Task.Run(() =>
            {
                var classes = Database.GetList<Class>(c => c.Id > 0);
                foreach (var c in classes)
                {
                    c.CountStudent(Database);
                }
                Classes = new ObservableCollection<Class> (classes);
            });
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
