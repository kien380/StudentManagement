using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : IMasterDetailPageOptions
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;

        protected override void OnAppearing()
        {
            IsGestureEnabled = true;
        }

        protected override void OnDisappearing()
        {
            IsGestureEnabled = false;
        }
    }
}