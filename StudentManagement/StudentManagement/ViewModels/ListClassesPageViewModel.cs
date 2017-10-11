using Prism.Navigation;
using StudentManagement.Interfaces;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class ListClassesPageViewModel : ViewModelBase
    {
        public ListClassesPageViewModel(INavigationService navigationService, ISQLiteHelper sqLiteHelper)
            : base(navigationService, sqLiteHelper)
        {
            PageTitle = "Danh sách các lớp";
        }
    }
}
