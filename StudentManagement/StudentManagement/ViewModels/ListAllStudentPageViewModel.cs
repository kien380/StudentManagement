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
    public class ListAllStudentPageViewModel : ViewModelBase
    {
        #region private properties
        
        private ObservableCollection<Student> _students;

        #endregion

        #region public properties
        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetProperty(ref _students, value);
        }
        #endregion
        public ListAllStudentPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            PageTitle = "Danh sách học sinh";

            var students = sqLiteHelper.GetList<Student>(s => s.Id > 0);
            Students = new ObservableCollection<Student>(students);
        }

        #region Methods

        public void StudentItemTapped(Student student)
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.StudentInfo.ToString(), student }
            };
            NavigationService.NavigateAsync(PageManager.DetailStudentPage, navParam);
        }

        #endregion
    }
}
