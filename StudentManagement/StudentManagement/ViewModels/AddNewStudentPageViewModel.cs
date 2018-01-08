using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Enums;
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
        private AddNewStudentType _type;

        private string _buttonName;
        private Student _student;
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
        public string ButtonName
        {
            get => _buttonName;
            set => SetProperty(ref _buttonName, value);
        }

        // Commands
        public ICommand ContinueCommand { get; set; }
        #endregion

        public AddNewStudentPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Set values

            // Commands
            ContinueCommand = new DelegateCommand(ContinueExecute);
        }

        public override void OnNavigatedNewTo(NavigationParameters parameters)
        {
            if (parameters != null)
            {
                if (parameters.ContainsKey(ParamKey.StudentInfo.ToString()))
                {
                    _student = (Student)parameters[ParamKey.StudentInfo.ToString()];
                    FullName = _student.FullName;
                    DoB = _student.DoB;
                    Gender = _student.GenderString;
                    Email = _student.Email;
                    Address = _student.Address;
                }

                if (parameters.ContainsKey(ParamKey.AddNewStudentType.ToString()))
                {
                    SwitchPageType((AddNewStudentType)parameters[ParamKey.AddNewStudentType.ToString()]);
                }
            }
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


            if (_type == AddNewStudentType.AddNew)
            {
                var student = new Student();

                // Get student ID
                await Task.Run(() =>
                {
                    var students = Database.GetList<Student>(s => s.Id > 0);
                    int idMax = students.Select(s => s.Id).Concat(new[] {0}).Max();

                    student.Id = ++idMax;
                    student.FullName = FullName;
                    student.DoB = DoB;
                    student.Gender = Gender == "Nam" ? 1 : 0;
                    student.Email = Email;
                    student.Address = Address;
                });
                var navParam = new NavigationParameters
                {
                    {ParamKey.StudentInfo.ToString(), student}
                };
                await NavigationService.NavigateAsync(PageManager.ChooseClassPage, navParam);
            }
            else
            {
                _student.FullName = FullName;
                _student.DoB = DoB;
                _student.Gender = Gender == "Nam" ? 1 : 0;
                _student.Email = Email;
                _student.Address = Address;

                Database.Update(_student);
                await Dialog.DisplayAlertAsync("Thông báo", "Lưu thông tin học sinh thành công", "OK");
                await NavigationService.GoBackAsync(new NavigationParameters
                {
                    { ParamKey.NeedReload.ToString(), true }
                });
            }
        }


        private void SwitchPageType(AddNewStudentType type)
        {
            _type = type;
            switch (type)
            {
                case AddNewStudentType.AddNew:
                    PageTitle = "Tiếp nhận học sinh";
                    DoB = new DateTime(2001, 1, 1);
                    ButtonName = "Tiếp theo";
                    break;

                case AddNewStudentType.UpdateInfo:
                    PageTitle = "Sửa thông tin học sinh";
                    ButtonName = "Lưu";
                    break;
            }
        }
        #endregion
    }
}
