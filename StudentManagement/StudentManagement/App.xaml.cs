using Prism.Unity;
using StudentManagement.Helpers;
using StudentManagement.Views;
using Xamarin.Forms;

namespace StudentManagement
{
    public partial class App : PrismApplication
    {
        public App()
        {
            
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                PageManager.NavigationPage, PageManager.HomePage
            }));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>(PageManager.NavigationPage);
            Container.RegisterTypeForNavigation<HomePage>(PageManager.HomePage);
        }
    }
}
