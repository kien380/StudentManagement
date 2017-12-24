using System;
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

        #endregion

        #region public properties
        public User CurrentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }
        // commads
        public ICommand AddNewStudentCommand { get; set; }
        public ICommand ListClassesCommand { get; set; }
        public ICommand ListAllStudentCommand { get; set; }
        public ICommand InputScoreBoardCommand { get; set; }
        public ICommand ShowReportCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        #endregion


        public HomePageViewModel(INavigationService navigationService, ISQLiteHelper sqLiteHelper) 
            : base(navigationService, sqLiteHelper: sqLiteHelper)
        {
            // Set values
            PageTitle = "Home Page";
            CurrentUser = Database.GetUser();

            // Commands
            AddNewStudentCommand = new DelegateCommand(AddNewStudentExecute);
            ListClassesCommand = new DelegateCommand(ListClassesExecute);
            ListAllStudentCommand = new DelegateCommand(ListAllStudentExecute);
            InputScoreBoardCommand = new DelegateCommand(InputScoreBoardExecute);
            ShowReportCommand = new DelegateCommand(ShowReportExecute);
            SettingCommand = new DelegateCommand(SettingExecute);
            LogOutCommand = new DelegateCommand(LogOutExecute);
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

        #endregion
    }
}
