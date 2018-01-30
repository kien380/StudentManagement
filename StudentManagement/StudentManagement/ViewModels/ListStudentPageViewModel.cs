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
    public class ListStudentPageViewModel : ViewModelBase
    {
        #region private properties

        private string _className;
        private ObservableCollection<Student> _students;
        private Class _class;

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
            
            // Commands
        }

        #region override

        public override void OnNavigatedNewTo(NavigationParameters parameters)
        {
            base.OnNavigatedNewTo(parameters);

            if (parameters != null)
            {
                if (parameters.ContainsKey(ParamKey.ClassInfo.ToString()))
                {
                    SetClassInfo((Class)parameters[ParamKey.ClassInfo.ToString()]);
                }
            }
        }

        private void SetClassInfo(Class classInfo)
        {
            _class = classInfo;
            ClassName = classInfo.Name;
            Students = new ObservableCollection<Student>(Database.GetList<Student>(s=>s.ClassId == _class.Id));
        }

        #endregion

        #region Methods

        public void StudentItemTapped(Student student)
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.StudentInfo.ToString(), student },
                { ParamKey.DetailStudentPageType.ToString(), DetailStudentPageType.StudentInfo }
            };
            NavigationService.NavigateAsync(PageManager.DetailStudentPage, navParam);
        }

        #endregion
    }
}
