using System.Collections.ObjectModel;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class ListStudentPageViewModel : ViewModelBase
    {
        #region private properties

        private string _className;
        private ObservableCollection<Student> _students;

        #endregion

        #region public properties
        public string ClassName
        {
            get => _className;
            set => SetProperty(ref _className, value);
        }
        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetProperty(ref _students, value);
        }
        #endregion

        public ListStudentPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Set values
            PageTitle = "Danh sách lớp";
            ClassName = "10A4";
            Students = new ObservableCollection<Student>{ new Student(), new Student(), new Student(), new Student(), new Student(), new Student()};

            // Commands
        }
    }
}
