﻿namespace StudentManagement.Helpers
{
    public class PageManager
    {
        public static readonly string NavigationPage = "NavigationPage";
        public static readonly string LoginPage = "LoginPage";
        public static readonly string HomePage = "HomePage";
        public static readonly string ListClassesPage = "ListClassesPage";
        public static readonly string ListStudentsPage = "ListStudentsPage";
        public static readonly string DetailClassPage = "DetailClassPage";
        public static readonly string AddNewStudentPage = "AddNewStudentPage";
        public static readonly string ChooseClassPage = "ChooseClassPage";


        public static string MultiplePage(string[] pages)
        {
            string path = "";
            if (pages == null) return "";
            if (pages.Length < 1) return "";
            for (int i = 0; i < pages.Length; i++)
            {
                path += i == 0 ? pages[i] : "/" + pages[i];
            }
            return path;
        }
    }
}
