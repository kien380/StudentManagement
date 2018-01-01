using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Helpers;
using StudentManagement.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentScorePage : ContentPage
	{
		public StudentScorePage ()
		{
			InitializeComponent ();
		}

	    protected override void OnBindingContextChanged()
	    {
	        base.OnBindingContextChanged();
            if (BindingContext != null)
	        {
	            try
	            {
	                var vm = (StudentScorePageViewModel)BindingContext;
	                var user = vm.Database.GetUser();
	                if (user.Role.Equals(RoleManager.PrincipalRole))
	                {
	                    this.ToolbarItems.Add(new ToolbarItem
	                    {
	                        Text = "Edit",
                            Icon = "ic_ic_edit_white.png",
                            Command = vm.EditCommand
                        });
	                }
	            }
	            catch (Exception e)
	            {
	                Debug.WriteLine(e.Message);
	            }
	        }
	    }
	}
}