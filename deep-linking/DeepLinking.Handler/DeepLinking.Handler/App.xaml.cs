using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DeepLinking.Handler
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnAppLinkRequestReceived(Uri uri)
        {
            // Parse the uri to determine where in your app you need to go.
            // This is the same uri you registered above.
            var parametersSplit = uri.ToString().Split('/');

            if (parametersSplit[3] == "1")
                await MainPage.Navigation.PushAsync(new Page1View());
            else if (parametersSplit[3] == "2")
                await MainPage.Navigation.PushAsync(new Page2View());

            base.OnAppLinkRequestReceived(uri);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
