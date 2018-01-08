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
    public partial class ChangeClassesInfoPage : ContentPage
    {
        private ChangeClassesInfoPageViewModel _vm;
        public ChangeClassesInfoPage()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            if (BindingContext != null)
                _vm = (ChangeClassesInfoPageViewModel)BindingContext;
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListClasses.SelectedItem = null;
        }

        private void EditIcon_Tapped(object sender, EventArgs e)
        {
            var icon = (Image)sender;
            var _class = (Class)icon.BindingContext;
            _vm.EditExecute(_class);
        }

        private void RemoveIcon_Tapped(object sender, EventArgs e)
        {
            var icon = (Image)sender;
            var _class = (Class)icon.BindingContext;
            _vm.RemoveExecute(_class);
        }
    }
}