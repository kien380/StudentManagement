using System;
using System.Threading.Tasks;
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
    public class AddNewStudentPageViewModel : ViewModelBase
    {
        #region private properties

        private string _fullName;
        private DateTime _doB;
        private string _gender;
        private string _email;
        private string _address;

        #endregion

        #region public properties
        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }
        public DateTime DoB
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
        public ICommand ContinueCommand { get; set; }
        #endregion

        public AddNewStudentPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Set values
            PageTitle = "Tiếp nhận học sinh";

            // Commands
            ContinueCommand = new DelegateCommand(ContinueExecute);
        }

        #region Methods

        private async void ContinueExecute()
        {

            // Add Student into database
            await Task.Run(() =>
            {
                var student = new Student
                {
                    Id = 19999,
                    FullName = FullName,
                    DoB = DoB,
                    Gender = Gender == "Nam" ? 1 : 0,
                    Email = Email,
                    Address = Address
                };
                Database.Insert(student);
            });

            await NavigationService.NavigateAsync(PageManager.ChooseClassPage);
        }

        #endregion
    }
}
