using System.Collections.Generic;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class ReportHomePageViewModel : ViewModelBase
    {
        public ReportHomePageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            PageTitle = "Báo cáo tổng kết";
        }
    }
}
