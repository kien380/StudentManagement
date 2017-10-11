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
        public DelegateCommand LogOutCommand { get; set; }
        #endregion


        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PageTitle = "Home Page";
            LogOutCommand = new DelegateCommand(LogOutExecute);
        }

        #region Methods

        private void LogOutExecute()
        {
            NavigationService.NavigateAsync(PageManager.MultiplePage(new []
            {
                PageManager.LoginPage
            }));
        }

        #endregion
    }
}
