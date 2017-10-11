using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.ViewModels.Base;

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

        private void LoginExecute()
        {
            NavigationService.GoBackAsync();
        }

        #endregion
    }
}
