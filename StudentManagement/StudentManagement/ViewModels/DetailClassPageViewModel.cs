using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
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

        // Commands
        public ICommand ViewListStudentCommand { get; set; }
        public ICommand ViewScoreBoardCommand { get; set; }
        #endregion

        public DetailClassPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            // Set values
            PageTitle = "Thông tin lớp";
            ClassName = "10A4";
            NumberOfStudent = 30;
            NumberOfBoy = 10;
            NumberOfGirl = 20;

            // Commands
            ViewListStudentCommand = new DelegateCommand(ViewListStudentExecute);
            ViewScoreBoardCommand = new DelegateCommand(ViewScoreBoardExecute);
        }

        #region Methods

        private void ViewListStudentExecute()
        {
            NavigationService.NavigateAsync(PageManager.ListStudentsPage);
        }

        private void ViewScoreBoardExecute()
        {
            
        }

        #endregion
    }
}
