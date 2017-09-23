using Prism.Commands;
using Prism.Navigation;
using StudentManagement.Helpers;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region priavte properties


        #endregion

        #region public properties
        public DelegateCommand OkCommand { get; set; }
        

        #endregion


        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PageTitle = "Home Page";
            OkCommand = new DelegateCommand(OkExecute);
        }

        #region Methods

        private void OkExecute()
        {
            NavigationService.NavigateAsync(PageManager.HomePage);
        }

        #endregion
    }
}
