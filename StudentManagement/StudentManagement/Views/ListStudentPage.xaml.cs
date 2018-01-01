using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Helpers;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListStudentPage : ContentPage
	{
		public ListStudentPage ()
		{
			InitializeComponent ();
		}

	    private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var student = (Student)e.Item;
	        ListViewStudents.SelectedItem = null;
	        var vm = (ListStudentPageViewModel)BindingContext;
	        var user = vm.Database.GetUser();
            if(user.Role.Equals(RoleManager.StudentRole))
                return;
	        vm.StudentItemTapped(student);
        }
	}
}