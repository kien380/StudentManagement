using StudentManagement.Models;
using StudentManagement.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListClassesPage : ContentPage
    {
        public ListClassesPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var _class = (Class) e.Item;
            ListViewClasses.SelectedItem = null;
            var vm = (ListClassesPageViewModel) BindingContext;
            vm.ClassesItemTapped(_class);
        }
    }
}