﻿using Prism.Mvvm;
using Prism.Navigation;
using StudentManagement.Interfaces;

namespace StudentManagement.ViewModels.Base
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        protected INavigationService NavigationService;
        protected ISQLiteHelper Database;

        public ViewModelBase(
            INavigationService navigationService = null,
            ISQLiteHelper sqLiteHelper = null)
        {
            if (navigationService != null) NavigationService = navigationService;
            if (sqLiteHelper != null) Database = sqLiteHelper;
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
