using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage 
	{
		public LoginPage ()
		{
			InitializeComponent ();
            //NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}