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
    public class DetailClassPageViewModel : ViewModelBase
    {
        #region private properties
        
        private string _className;
        private int _numberOfStudent;
        private int _numberOfBoy;
        private int _numberOfGirl;
        private bool _isClassInfo;
        private bool _isClassAcceptStudent;
        private Class _class;

        #endregion

        #region public properties
        public string ClassName
        {
            get => _className;
            set => SetProperty(ref _className, value);
        }
        public int NumberOfStudent
        {
            get => _numberOfStudent;
            set => SetProperty(ref _numberOfStudent, value);
        }
        public int NumberOfBoy
        {
            get => _numberOfBoy;
            set => SetProperty(ref _numberOfBoy, value);
        }
        public int NumberOfGirl
        {
            get => _numberOfGirl;
            set => SetProperty(ref _numberOfGirl, value);
        }
        public bool IsClassInfo
        {
            get => _isClassInfo;
            set => SetProperty(ref _isClassInfo, value);
        }
        public bool IsClassAcceptStudent
        {
            get => _isClassAcceptStudent;
            set => SetProperty(ref _isClassAcceptStudent, value);
        }

        // Commands
        public ICommand ViewListStudentCommand { get; set; }
        public ICommand ViewScoreBoardCommand { get; set; }
        public ICommand AcceptCommand { get; set; }
        #endregion

        public DetailClassPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Commands
            ViewListStudentCommand = new DelegateCommand(ViewListStudentExecute);
            ViewScoreBoardCommand = new DelegateCommand(ViewScoreBoardExecute);
            AcceptCommand = new DelegateCommand(AcceptExecute);
        }

        #region Override

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters != null)
            {
                if (parameters.ContainsKey(ParamKey.DetailClassPageType.ToString()))
                {
                    SwitchPageMode((DetailClassPageType)parameters[ParamKey.DetailClassPageType.ToString()]);
                }
                if (parameters.ContainsKey(ParamKey.ClassInfo.ToString()))
                {
                    SetClassInfo((Class)parameters[ParamKey.ClassInfo.ToString()]);
                }
            }
        }

        private void SetClassInfo(Class classInfo)
        {
            _class = classInfo;
            ClassName = classInfo.Name;
            NumberOfStudent = classInfo.Students;
            NumberOfBoy = classInfo.Boys;
            NumberOfGirl = classInfo.Girls;
        }

        #endregion

        #region Methods

        private void ViewListStudentExecute()
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.ClassInfo.ToString(), _class }
            };
            NavigationService.NavigateAsync(PageManager.ListStudentsPage, navParam);
        }

        private void ViewScoreBoardExecute()
        {
            //var navParam = new NavigationParameters
            //{
            //    { ParamKey.ScoreBoardPageType.ToString(), ScoreBoardPageType.ViewScoreBoard }
            //};
            NavigationService.NavigateAsync(PageManager.ScoreBoardPage);
        }

        private void AcceptExecute()
        {
            NavigationService.NavigateAsync(PageManager.DetailStudentPage);
        }

        private void SwitchPageMode(DetailClassPageType type)
        {
            switch (type)
            {
                case DetailClassPageType.ClassInfo:
                    IsClassAcceptStudent = false;
                    IsClassInfo = true;
                    PageTitle = "Thông tin lớp";
                    break;

                case DetailClassPageType.ClassAcceptStudent:
                    IsClassAcceptStudent = true;
                    IsClassInfo = false;
                    PageTitle = "Chọn lớp";
                    break;
            }
        }

        #endregion
    }
}
