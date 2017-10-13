using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Enums;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class DetailStudentPageViewModel : ViewModelBase
    {
        #region private properties

        private string _className;
        private string _fullName;
        private string _doB;
        private string _gender;
        private string _email;
        private string _address;

        #endregion

        #region public properties
        public string ClassName
        {
            get => _className;
            set => SetProperty(ref _className, value);
        }
        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }
        public string DoB
        {
            get => _doB;
            set => SetProperty(ref _doB, value);
        }
        public string Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
        // Commands
        public ICommand ViewClassInfoCommand { get; set; }
        public ICommand ViewScoreBoardCommand { get; set; }
        #endregion
        public DetailStudentPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Set values
            ClassName = "10A4";
            PageTitle = "Thông tin học sinh";
            FullName = "Nguyễn Văn A";
            DoB = "19/5/1996";
            Gender = "Nam";
            Email = "nguyenvana@gmail.com";
            Address = "Linh Trung, Thủ Đức, TP HCM";

            // Commands
            ViewClassInfoCommand = new DelegateCommand(ViewClassInfoExecute);
            ViewScoreBoardCommand = new DelegateCommand(ViewScoreBoardExecute);
        }

        #region Methods

        private void ViewClassInfoExecute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.DetailClassPageType.ToString(), DetailClassPageType.ClassInfo }
            };
            NavigationService.NavigateAsync(PageManager.DetailClassPage, navParam);
        }

        private void ViewScoreBoardExecute()
        {

        }

        #endregion
    }
}
