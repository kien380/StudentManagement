using System.Collections.ObjectModel;
using Prism.Navigation;
using Prism.Services;
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
            Students = new ObservableCollection<Student> { new Student(), new Student(), new Student(), new Student(), new Student(), new Student() };
        }

        #region Methods

        public void StudentItemTapped(Student student)
        {
            NavigationService.NavigateAsync(PageManager.DetailStudentPage);
        }

        #endregion
    }
}
