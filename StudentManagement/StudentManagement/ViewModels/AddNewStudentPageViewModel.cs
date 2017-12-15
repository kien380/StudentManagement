using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;
using StudentManagement.Views.Popups;

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
            DoB = new DateTime(2001,1,1);

            // Commands
            ContinueCommand = new DelegateCommand(ContinueExecute);
        }

        #region Methods

        private async void ContinueExecute()
        {
            var settings = Database.GetSetting();

            if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Gender) ||
                string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Address))
            {
                await Dialog.DisplayAlertAsync("Thông báo", "Bạn cần nhập đầy đủ thông tin học sinh", "OK");
                return;
            }

            if (settings.MinStudentAge > 2017 - DoB.Year || settings.MaxStudentAge < 2017 - DoB.Year)
            {
                await Dialog.DisplayAlertAsync("Thông báo", "Tuổi của học sinh không hợp lệ", "OK");
                return;
            }

            LoadingPopup.Instance.ShowLoading();
            // Add Student into database
            await Task.Run(() =>
            {
                var students = Database.GetList<Student>(s => s.Id > 0);
                int idMax = students.Select(s => s.Id).Concat(new[] {0}).Max();

                var student = new Student
                {
                    Id = ++idMax,
                    FullName = FullName,
                    DoB = DoB,
                    Gender = Gender == "Nam" ? 1 : 0,
                    Email = Email,
                    Address = Address
                };
                Database.Insert(student);
            });
            LoadingPopup.Instance.HideLoading();

            await NavigationService.NavigateAsync(PageManager.ChooseClassPage);
        }

        #endregion
    }
}
