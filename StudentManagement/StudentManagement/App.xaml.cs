﻿using DryIoc;
using Prism.DryIoc;
using StudentManagement.Helpers;
using StudentManagement.Interfaces;
using StudentManagement.Models;
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
            InitMockData();
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
            Container.RegisterTypeForNavigation<ListAllStudentPage>(PageManager.ListAllStudentsPage);
            Container.RegisterTypeForNavigation<DetailClassPage>(PageManager.DetailClassPage);
            Container.RegisterTypeForNavigation<DetailStudentPage>(PageManager.DetailStudentPage);
            Container.RegisterTypeForNavigation<AddNewStudentPage>(PageManager.AddNewStudentPage);
            Container.RegisterTypeForNavigation<ChooseClassPage>(PageManager.ChooseClassPage);
            Container.RegisterTypeForNavigation<ScoreBoardPage>(PageManager.ScoreBoardPage);
            Container.RegisterTypeForNavigation<StudentScorePage>(PageManager.StudentScorePage);
            Container.RegisterTypeForNavigation<ReportBySubjectPage>(PageManager.ReportBySubjectPage);
            Container.RegisterTypeForNavigation<ReportHomePage>(PageManager.ReportHomePage);

            // Register Services
            Container.Register<ISQLiteHelper, SQLiteHelper>(Reuse.ScopedOrSingleton);
        }

        private void InitDatabase()
        {
            var connectionService = DependencyService.Get<IDatabaseConnection>();
            _sqLiteHelper = new SQLiteHelper(connectionService);
        }

        private void InitMockData()
        {
            var setting = _sqLiteHelper.Get<Setting>("1");
            if (setting != null)
            {
                if (!setting.IsInitData)
                {
                    var mockData = new MockData(_sqLiteHelper);
                    mockData.InitMockData();
                }
                //else
                //{
                //    List<Score> scores = _sqLiteHelper.GetList<Score>(s => s.Id >= 0).ToList();
                //}
            }
            else
            {
                var mockData = new MockData(_sqLiteHelper);
                mockData.InitMockData();
            }
        }
    }
}
