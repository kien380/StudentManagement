using System;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using StudentManagement.Enums;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region private properties

        private User _currentUser;
        private bool _isAddNewStudentVisible;
        private bool _isListClassesVisible;
        private bool _isListAllStudentVisible;
        private bool _isInputScoreBoardVisible;
        private bool _isShowReportVisible;
        private bool _isSettingVisible;
        private bool _isStudentDetailVisible;
        private bool _isClassDetailVisible;
        private bool _isStudentsInClassVisible;
        private bool _isScoreInClassVisible;
        private bool _isScoreSemester1Visible;
        private bool _isScoreSemester2Visible;
        private bool _isScoreSemesterAllYearVisible;

        #endregion

        #region public properties
        public User CurrentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }
        public bool IsAddNewStudentVisible
        {
            get => _isAddNewStudentVisible;
            set => SetProperty(ref _isAddNewStudentVisible, value);
        }
        public bool IsListClassesVisible
        {
            get => _isListClassesVisible;
            set => SetProperty(ref _isListClassesVisible, value);
        }
        public bool IsListAllStudentVisible
        {
            get => _isListAllStudentVisible;
            set => SetProperty(ref _isListAllStudentVisible, value);
        }
        public bool IsInputScoreBoardVisible
        {
            get => _isInputScoreBoardVisible;
            set => SetProperty(ref _isInputScoreBoardVisible, value);
        }
        public bool IsShowReportVisible
        {
            get => _isShowReportVisible;
            set => SetProperty(ref _isShowReportVisible, value);
        }
        public bool IsSettingVisible
        {
            get => _isSettingVisible;
            set => SetProperty(ref _isSettingVisible, value);
        }
        public bool IsStudentDetailVisible
        {
            get => _isStudentDetailVisible;
            set => SetProperty(ref _isStudentDetailVisible, value);
        }
        public bool IsStudentsInClassVisible
        {
            get => _isStudentsInClassVisible;
            set => SetProperty(ref _isStudentsInClassVisible, value);
        }
        public bool IsScoreSemester1Visible
        {
            get => _isScoreSemester1Visible;
            set => SetProperty(ref _isScoreSemester1Visible, value);
        }
        public bool IsScoreSemester2Visible
        {
            get => _isScoreSemester2Visible;
            set => SetProperty(ref _isScoreSemester2Visible, value);
        }
        public bool IsScoreSemesterAllYearVisible
        {
            get => _isScoreSemesterAllYearVisible;
            set => SetProperty(ref _isScoreSemesterAllYearVisible, value);
        }
        public bool IsScoreInClassVisible
        {
            get => _isScoreInClassVisible;
            set => SetProperty(ref _isScoreInClassVisible, value);
        }
        public bool IsClassDetailVisible
        {
            get => _isClassDetailVisible;
            set => SetProperty(ref _isClassDetailVisible, value);
        }
        // commads
        public ICommand AddNewStudentCommand { get; set; }
        public ICommand ListClassesCommand { get; set; }
        public ICommand ListAllStudentCommand { get; set; }
        public ICommand InputScoreBoardCommand { get; set; }
        public ICommand ShowReportCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand StudentDetailCommand { get; set; }
        public ICommand StudentsInClassCommand { get; set; }
        public ICommand ScoreSemester1Command { get; set; }
        public ICommand ScoreSemester2Command { get; set; }
        public ICommand ScoreSemesterAllYearCommand { get; set; }
        public ICommand ClassDetailCommand { get; set; }
        public ICommand ScoreInClassCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        #endregion


        public HomePageViewModel(INavigationService navigationService, ISQLiteHelper sqLiteHelper) 
            : base(navigationService, sqLiteHelper: sqLiteHelper)
        {
            // Set values
            PageTitle = "Home Page";

            // Commands
            AddNewStudentCommand = new DelegateCommand(AddNewStudentExecute);
            ListClassesCommand = new DelegateCommand(ListClassesExecute);
            ListAllStudentCommand = new DelegateCommand(ListAllStudentExecute);
            InputScoreBoardCommand = new DelegateCommand(InputScoreBoardExecute);
            ShowReportCommand = new DelegateCommand(ShowReportExecute);
            SettingCommand = new DelegateCommand(SettingExecute);
            StudentDetailCommand = new DelegateCommand(StudentDetailExecute);
            StudentsInClassCommand = new DelegateCommand(StudentsInClassExecute);
            ScoreSemester1Command = new DelegateCommand(ScoreSemester1Execute);
            ScoreSemester2Command = new DelegateCommand(ScoreSemester2Execute);
            ScoreSemesterAllYearCommand = new DelegateCommand(ScoreSemesterAllYearExecute);
            ClassDetailCommand = new DelegateCommand(ClassDetailExecute);
            ScoreInClassCommand = new DelegateCommand(ScoreInClassExecute);
            LogOutCommand = new DelegateCommand(LogOutExecute);

            InitUser();
        }

        private void InitUser()
        {
            CurrentUser = Database.GetUser();

            // Set View depend on user's role
            IsAddNewStudentVisible = CurrentUser.Role.Equals(RoleManager.PrincipalRole);
            IsListClassesVisible = CurrentUser.Role.Equals(RoleManager.PrincipalRole);
            IsListAllStudentVisible = CurrentUser.Role.Equals(RoleManager.PrincipalRole);
            IsInputScoreBoardVisible = CurrentUser.Role.Equals(RoleManager.PrincipalRole);
            IsShowReportVisible = CurrentUser.Role.Equals(RoleManager.PrincipalRole);
            IsSettingVisible = CurrentUser.Role.Equals(RoleManager.PrincipalRole);
            IsStudentDetailVisible = CurrentUser.Role.Equals(RoleManager.StudentRole);
            IsStudentsInClassVisible = CurrentUser.Role.Equals(RoleManager.StudentRole)
                || CurrentUser.Role.Equals(RoleManager.TeacherRole);
            IsScoreSemester1Visible = CurrentUser.Role.Equals(RoleManager.StudentRole);
            IsScoreSemester2Visible = CurrentUser.Role.Equals(RoleManager.StudentRole);
            IsScoreSemesterAllYearVisible = CurrentUser.Role.Equals(RoleManager.StudentRole);
            IsClassDetailVisible = CurrentUser.Role.Equals(RoleManager.TeacherRole);
            IsScoreInClassVisible = CurrentUser.Role.Equals(RoleManager.TeacherRole);
        }

        #region Overrides

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        #endregion

        #region Methods

        private void AddNewStudentExecute()
        {
            NavigationService.NavigateAsync(PageManager.MultiplePage(new []
            {
                PageManager.NavigationPage, PageManager.AddNewStudentPage
            }));
        }

        private void ListClassesExecute()
        {
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.ListClassesPage
            }));
        }

        private void ListAllStudentExecute()
        {
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.ListAllStudentsPage
            }));
        }

        private void InputScoreBoardExecute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.ScoreBoardPageType.ToString(), ScoreBoardPageType.InputScoreBoard }
            };
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.ScoreBoardPage
            }), navParam);
        }

        private void ShowReportExecute()
        {
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.ReportHomePage
            }));
        }

        private void SettingExecute()
        {
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.SettingsPage
            }));
        }

        private void LogOutExecute()
        {
            CurrentUser = null;
            UserHelper.Instance.Logout(Database);
            NavigationService.NavigateAsync(new Uri($"https://kienhht.com/{PageManager.LoginPage}"));
        }

        private void StudentDetailExecute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.StudentInfo.ToString(), Database.Get<Student>(s=>s.Id==CurrentUser.Id) },
                { ParamKey.DetailStudentPageType.ToString(), DetailStudentPageType.StudentInfo }
            };
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.DetailStudentPage
            }), navParam);
        }

        private void StudentsInClassExecute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.ClassInfo.ToString(), Database.Get<Class>(c=>c.Id==CurrentUser.ClassId) }
            };
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.ListStudentsPage
            }),navParam);
        }

        private void ScoreSemester1Execute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.Semester.ToString(), 1 },
                { ParamKey.StudentInfo.ToString(), Database.Get<Student>(s=>s.Id==CurrentUser.Id) }
            };
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.PersonalScoreListPage
            }), navParam);
        }

        private void ScoreSemester2Execute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.Semester.ToString(), 2 },
                { ParamKey.StudentInfo.ToString(), Database.Get<Student>(s=>s.Id==CurrentUser.Id) }
            };
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.PersonalScoreListPage
            }), navParam);
        }

        private void ScoreSemesterAllYearExecute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.Semester.ToString(), 0 },
                { ParamKey.StudentInfo.ToString(), Database.Get<Student>(s=>s.Id==CurrentUser.Id) }
            };
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.PersonalScoreListPage
            }), navParam);
        }

        private void ScoreInClassExecute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.ClassInfo.ToString(), Database.Get<Class>(c=>c.Id==CurrentUser.ClassId) }
            };
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.ScoreBoardPage
            }), navParam);
        }

        private void ClassDetailExecute()
        {
            var classInfo = Database.Get<Class>(c => c.Id == CurrentUser.ClassId);
            classInfo.CountStudent(Database);
            var navParam = new NavigationParameters
            {
                { ParamKey.DetailClassPageType.ToString(), DetailClassPageType.ClassInfo },
                { ParamKey.ClassInfo.ToString(), classInfo }
            };
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.DetailClassPage
            }), navParam);
        }

        #endregion
    }
}
