using StudentManagement.Models;
using StudentManagement.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseClassPage : ContentPage
    {
        public ChooseClassPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var _class = (Class)e.Item;
            ListViewClasses.SelectedItem = null;
            var vm = (ChooseClassPageViewModel)BindingContext;
            vm.ClassesItemTapped(_class);
        }
    }
}