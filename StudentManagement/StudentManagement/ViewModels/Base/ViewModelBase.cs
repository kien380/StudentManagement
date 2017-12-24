using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Interfaces;

namespace StudentManagement.ViewModels.Base
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        protected INavigationService NavigationService;
        protected IPageDialogService Dialog;
        protected ISQLiteHelper Database;

        public ViewModelBase(
            INavigationService navigationService = null,
            IPageDialogService dialogService = null,
            ISQLiteHelper sqLiteHelper = null)
        {
            if (navigationService != null) NavigationService = navigationService;
            if (dialogService != null) Dialog = dialogService;
            if (sqLiteHelper != null) Database = sqLiteHelper;
        }
        
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters != null)
            {
                if (parameters.ContainsKey("__NavigationMode"))
                {
                    var navMode = (NavigationMode) parameters["__NavigationMode"];
                    switch (navMode)
                    {
                        case NavigationMode.New: OnNavigatedNewTo(parameters); break;
                        case NavigationMode.Back: OnNavigatedBackTo(parameters); break;
                    }
                }
            }
        }

        public virtual void OnNavigatedNewTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedBackTo(NavigationParameters parameters)
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
