using StudentManagement.Models;
using StudentManagement.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAllStudentPage : ContentPage
    {
        public ListAllStudentPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var student = (Student)e.Item;
            ListViewStudents.SelectedItem = null;
            var vm = (ListAllStudentPageViewModel)BindingContext;
            vm.StudentItemTapped(student);
        }
    }
}