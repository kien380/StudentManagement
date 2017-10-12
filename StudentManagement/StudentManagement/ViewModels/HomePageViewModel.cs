using System;
using Prism.Commands;
using Prism.Navigation;
using StudentManagement.Helpers;
using StudentManagement.ViewModels.Base;
using Xamarin.Forms;

namespace StudentManagement.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region private properties

        private bool _isLogOut = false;

        #endregion

        #region public properties
        public DelegateCommand LogOutCommand { get; set; }
        #endregion


        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PageTitle = "Home Page";
            LogOutCommand = new DelegateCommand(LogOutExecute);
        }

        #region Overrides

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        #endregion

        #region Methods

        private void LogOutExecute()
        {
            _isLogOut = true;
            NavigationService.NavigateAsync(new Uri($"https://kienhht.com/{PageManager.LoginPage}"));
        }

        #endregion
    }
}
