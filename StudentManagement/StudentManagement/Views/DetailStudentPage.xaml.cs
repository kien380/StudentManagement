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
    public partial class DetailStudentPage : ContentPage
    {
        public DetailStudentPage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                try
                {
                    var vm = (DetailStudentPageViewModel)BindingContext;
                    var user = vm.Database.GetUser();
                    if (user.Role.Equals(RoleManager.PrincipalRole))
                    {
                        this.ToolbarItems.Add(new ToolbarItem
                        {
                            Text = "Remove",
                            Icon = "ic_remove_student.png",
                            Command = vm.RemoveStudentCommand
                        });
                        this.ToolbarItems.Add(new ToolbarItem
                        {
                            Text = "Edit",
                            Icon = "ic_ic_edit_white.png",
                            Command = vm.EditStudentCommand
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