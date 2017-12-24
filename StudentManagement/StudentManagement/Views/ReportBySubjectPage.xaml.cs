using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportBySubjectPage : ContentPage
    {
        public ReportBySubjectPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var c = (Class)e.Item;
            ListClass.SelectedItem = null;
            var vm = (ReportBySubjectPageViewModel)BindingContext;
            vm.ListClassItemTapped(c);
        }
    }
}