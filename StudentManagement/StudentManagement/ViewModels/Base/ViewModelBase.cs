using Prism.Mvvm;
using Prism.Navigation;

namespace StudentManagement.ViewModels.Base
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        protected INavigationService NavigationService;


        public ViewModelBase(INavigationService navigationService = null)
        {
            if (navigationService != null) NavigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        #region General Properties

        private string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        #endregion
    }
}
