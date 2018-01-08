using Prism.Navigation;
using Prism.Services;
using StudentManagement.Interfaces;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class ChangeClassesInfoPageViewModel : ViewModelBase
    {
        public ChangeClassesInfoPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
        }
    }
}
