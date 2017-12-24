using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.ViewModels.Base;
using StudentManagement.Views.Popups;

namespace StudentManagement.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region private properties

        private string _username;
        private string _password;

        #endregion

        #region private properties

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        // Commands
        public ICommand LoginCommand { get; set; }

        #endregion


        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Commands
            LoginCommand = new DelegateCommand(LoginExecute);
        }

        #region Methods

        private async void LoginExecute()
        {
            if(!await CheckEmpryUsernameOrPassword())
                return;

            LoadingPopup.Instance.ShowLoading();
            await Task.Delay(1000);
            if (!UserHelper.Instance.Login(Database, Username, Password))
            {
                LoadingPopup.Instance.HideLoading();
                await Dialog.DisplayAlertAsync("Thông báo", "Tên đăng nhập hoặc mật khẩu chưa chính xác", "OK");
                return;
            }
            await Task.Delay(1000);
            LoadingPopup.Instance.HideLoading();

            //Login success ==> Go to home page
            string uri = PageManager.MultiplePage(new[]
            {
                PageManager.HomePage, PageManager.NavigationPage, PageManager.ListClassesPage
            });
            await NavigationService.NavigateAsync(new Uri($"https://kienhht.com/{uri}"));
        }

        private async Task<bool> CheckEmpryUsernameOrPassword()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await Dialog.DisplayAlertAsync("Thông báo", "Bạn cần điền đầy đủ tên đăng nhập và mật khẩu", "OK");
                return false;
            }
            return true;
        }

        #endregion
    }
}
