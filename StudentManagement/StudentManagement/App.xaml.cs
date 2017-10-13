using DryIoc;
using Prism.DryIoc;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Services.LocalDatabase;
using StudentManagement.Views;
using Xamarin.Forms;

namespace StudentManagement
{
    public partial class App : PrismApplication
    {
        #region Properties

        private ISQLiteHelper _sqLiteHelper;
        #endregion

        public App()
        {
            
        }

        protected override void OnInitialized()
        {
            InitDatabase();
            InitializeComponent();
            NavigationService.NavigateAsync(PageManager.MultiplePage(new[]
            {
                //PageManager.LoginPage
                PageManager.HomePage, PageManager.NavigationPage, PageManager.ListClassesPage
            }));
        }

        protected override void RegisterTypes()
        {
            // Register Pages
            Container.RegisterTypeForNavigation<NavigationPage>(PageManager.NavigationPage);
            Container.RegisterTypeForNavigation<LoginPage>(PageManager.LoginPage);
            Container.RegisterTypeForNavigation<HomePage>(PageManager.HomePage);
            Container.RegisterTypeForNavigation<ListClassesPage>(PageManager.ListClassesPage);
            Container.RegisterTypeForNavigation<ListStudentPage>(PageManager.ListStudentsPage);
            Container.RegisterTypeForNavigation<DetailClassPage>(PageManager.DetailClassPage);

            // Register Services
            Container.Register<ISQLiteHelper, SQLiteHelper>(Reuse.ScopedOrSingleton);
        }

        private void InitDatabase()
        {
            var connectionService = DependencyService.Get<IDatabaseConnection>();
            _sqLiteHelper = new SQLiteHelper(connectionService);
        }
    }
}
