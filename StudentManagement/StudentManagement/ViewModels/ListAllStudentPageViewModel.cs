using System.Collections.ObjectModel;
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

namespace StudentManagement.ViewModels
{
    public class ListAllStudentPageViewModel : ViewModelBase
    {
        #region private properties
        
        private ObservableCollection<Student> _students;
        private ObservableCollection<Student> _allStudents;
        private bool _showSearchBox;
        private string _searchText;

        #endregion

        #region public properties
        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetProperty(ref _students, value);
        }
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public bool ShowSearchBox
        {
            get => _showSearchBox;
            set => SetProperty(ref _showSearchBox, value);
        }

        // Commands
        public ICommand SearchToolbarItemsCommand { get; set; }
        public ICommand SearchIconCommand { get; set; }
        #endregion

        public ListAllStudentPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            PageTitle = "Danh sách học sinh";
            SetListStudentData();

            // Commands
            SearchToolbarItemsCommand = new DelegateCommand(SearchToolbarItemsExecute);
            SearchIconCommand = new DelegateCommand(SearchIconExecute);
        }

        private void SetListStudentData()
        {
            Task.Run(() =>
            {
                var students = Database.GetList<Student>(s => s.Id > 0);
                foreach (var student in students)
                {
                    student.GetAvgScore(Database.GetList<Score>(s => s.StudentId == student.Id).ToList());
                }
                Students = _allStudents = new ObservableCollection<Student>(students);
            });
        }

        #region Methods

        public void StudentItemTapped(Student student)
        {
            var navParam = new NavigationParameters
            {
                { ParamKey.StudentInfo.ToString(), student }
            };
            NavigationService.NavigateAsync(PageManager.DetailStudentPage, navParam);
        }

        private void SearchToolbarItemsExecute()
        {
            ShowSearchBox = !ShowSearchBox;
        }

        private void SearchIconExecute()
        {
            var serchResult = _allStudents.Where(s => StringHelper.RemoveUnicodeCharacter(s.FullName.ToLower()).Contains(StringHelper.RemoveUnicodeCharacter(SearchText.ToLower())));
            Students = new ObservableCollection<Student>(serchResult);
        }

        #endregion
    }
}
