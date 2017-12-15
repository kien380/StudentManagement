using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagement.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPopup : PopupPage
    {
        public LoadingPopup()
        {
            InitializeComponent();
        }

        #region Instance

        private static LoadingPopup _instance;

        public static LoadingPopup Instance => _instance ?? (_instance = new LoadingPopup());

        public LoadingPopup ShowLoading(string loadingMessage = null)
        {
            LoadingIndicator.IsRunning = true;
            if (loadingMessage != null)
                LabelLoadingMessage.Text = loadingMessage;
            App.Current.MainPage.Navigation.PushPopupAsync(this);
            return this;
        }

        #endregion

        #region StopProcessing

        public void HideLoading()
        {
            if(LoadingIndicator.IsRunning)
            {
                LoadingIndicator.IsRunning = false;
                Navigation.PopPopupAsync();
            }
        }

        #endregion
    }
}