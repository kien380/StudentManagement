using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region private variable

        private Setting _settings;

        #endregion

        #region public variable

        public Setting Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        // Commands
        public ICommand SaveCommand { get; }

        #endregion

        public SettingsPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            PageTitle = "Quy định";
            SaveCommand = new DelegateCommand(SaveExecute);
        }

        #region override

        public override void OnNavigatedNewTo(NavigationParameters parameters)
        {
            if (parameters != null)
            {
                
            }

            Settings = Database.GetSetting();
        }

        #endregion

        #region Methods

        private async void SaveExecute()
        {
            Database.Update(Settings);
            await Dialog.DisplayAlertAsync("Thông báo", "Lưu thành công", "OK");

            // Go to home page
            string uri = PageManager.MultiplePage(new[]
            {
                PageManager.HomePage, PageManager.NavigationPage, PageManager.ListClassesPage
            });
            await NavigationService.NavigateAsync(new Uri($"https://kienhht.com/{uri}"));
        }

        #endregion
    }
}
