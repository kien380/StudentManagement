using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Enums;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class DetailStudentPageViewModel : ViewModelBase
    {
        #region private properties
        
        private Student _student;
        private string _className;
        private string _fullName;
        private string _doB;
        private string _gender;
        private string _email;
        private string _address;
        private string _avatar;
        private bool _isStudentInfo;
        private bool _isAddNewStudent;

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
        public string Avatar
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value);
        }
        public bool IsStudentInfo
        {
            get => _isStudentInfo;
            set => SetProperty(ref _isStudentInfo, value);
        }
        public bool IsAddNewStudent
        {
            get => _isAddNewStudent;
            set => SetProperty(ref _isAddNewStudent, value);
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
            PageTitle = "Thông tin học sinh";

            // Commands
            ViewClassInfoCommand = new DelegateCommand(ViewClassInfoExecute);
            ViewScoreBoardCommand = new DelegateCommand(ViewScoreBoardExecute);
        }

        #region override

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters != null)
            {
                if (parameters.ContainsKey(ParamKey.StudentInfo.ToString()))
                {
                    SetStudentInfo((Student)parameters[ParamKey.StudentInfo.ToString()]);
                }
                if (parameters.ContainsKey(ParamKey.DetailStudentPageType.ToString()))
                {
                    SwitchPageMode((DetailStudentPageType)parameters[ParamKey.DetailStudentPageType.ToString()]);
                }
            }
        }

        private void SetStudentInfo(Student student)
        {
            _student = student;
            ClassName = student.ClassName;
            FullName = student.FullName;
            DoB = student.DoB.ToString("dd/MM/yyyy");
            Gender = student.GenderString;
            Email = student.Email;
            Address = student.Address;
            Avatar = student.Avatar;
        }

        #endregion

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

        private void SwitchPageMode(DetailStudentPageType type)
        {
            switch (type)
            {
                case DetailStudentPageType.StudentInfo:
                    IsAddNewStudent = false;
                    IsStudentInfo = true;
                    break;

                case DetailStudentPageType.AddNewStudent:
                    IsAddNewStudent = true;
                    IsStudentInfo = false;
                    break;
            }
        }
        #endregion
    }
}
