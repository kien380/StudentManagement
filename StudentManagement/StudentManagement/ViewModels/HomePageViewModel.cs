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
        public DelegateCommand OkCommand { get; set; }
        public string Icons { get; set; }


        #endregion


        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PageTitle = "Home Page";
            OkCommand = new DelegateCommand(OkExecute);
            Icons = Ionicons.Transgender;
        }

        #region Methods

        private void OkExecute()
        {
            NavigationService.NavigateAsync(PageManager.HomePage);
        }

        #endregion
    }
}
