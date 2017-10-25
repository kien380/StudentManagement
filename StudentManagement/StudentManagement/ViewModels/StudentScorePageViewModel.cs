using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Interfaces;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class StudentScorePageViewModel : ViewModelBase
    {
        #region private properties
        
        private string _name;
        private float _score15M;
        private float _score45M;
        private float _scoreFinal;
        private float _scoreAvg;

        #endregion

        #region public properties
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public float Score15Mins
        {
            get => _score15M;
            set => SetProperty(ref _score15M, value);
        }
        public float Score45Mins
        {
            get => _score45M;
            set => SetProperty(ref _score45M, value);
        }
        public float ScoreFinal
        {
            get => _scoreFinal;
            set => SetProperty(ref _scoreFinal, value);
        }
        public float ScoreAvg
        {
            get => _scoreAvg;
            set => SetProperty(ref _scoreAvg, value);
        }
        // Commands
        public ICommand ClearCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        #endregion

        public StudentScorePageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Set values
            PageTitle = "Bảng điểm cá nhân";
            Name = "Nguyễn Văn A";

            // Commands
            ClearCommand = new DelegateCommand(ClearExecute);
            SaveCommand = new DelegateCommand(SaveExecute);
        }

        #region Methods

        private async void ClearExecute()
        {
            bool isAccept = await Dialog.DisplayAlertAsync("Xóa điểm", "Bạn có chắc muốn xóa điểm của học sinh?", "Có", "Không");
            if(isAccept)
            { }
        }

        private async void SaveExecute()
        {
            bool isAccept = await Dialog.DisplayAlertAsync("Lưu điểm", "Bạn có muốn lưu điểm của học sinh?", "Có", "Không");
            if (isAccept)
            { }
        }

        #endregion
    }
}
