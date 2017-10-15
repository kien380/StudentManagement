using System.Collections.ObjectModel;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Enums;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class ScoreBoardPageViewModel : ViewModelBase
    {
        #region private properties

        private ObservableCollection<Student> _students;
        private ScoreBoardPageType _pageType;

        #endregion

        #region public properties
        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetProperty(ref _students, value);
        }
        #endregion

        public ScoreBoardPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            PageTitle = "Bảng điểm";
            Students = new ObservableCollection<Student> { new Student(), new Student(), new Student(), new Student(), new Student(), new Student() };
        }

        #region Override

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters != null)
            {
                if (parameters.ContainsKey(ParamKey.ScoreBoardPageType.ToString()))
                {
                    _pageType = (ScoreBoardPageType)parameters[ParamKey.ScoreBoardPageType.ToString()];
                }
            }
        }

        #endregion

        #region Methods

        public void ScoreBoardItemTapped(Student student)
        {
            if (_pageType != ScoreBoardPageType.InputScoreBoard)
                return;

            NavigationService.NavigateAsync(PageManager.DetailStudentPage);
        }

        #endregion
    }
}
