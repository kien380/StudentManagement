using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using StudentManagement.Helpers;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region private properties
        

        #endregion

        #region public properties
        public ICommand AddNewStudentCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        #endregion


        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Set values
            PageTitle = "Home Page";

            // Commands
            AddNewStudentCommand = new DelegateCommand(AddNewStudentExecute);
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

        private void LogOutExecute()
        {
            NavigationService.NavigateAsync(new Uri($"https://kienhht.com/{PageManager.LoginPage}"));
        }

        #endregion
    }
}
