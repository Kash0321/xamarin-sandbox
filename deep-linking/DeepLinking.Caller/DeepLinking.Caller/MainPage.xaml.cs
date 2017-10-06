using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeepLinking.Caller
{
    public partial class MainPage : ContentPage
    {
        IOpenAppService OpenAppService = null;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();

            OpenAppService = DependencyService.Get<IOpenAppService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SubscribeToMessages();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            UnsubscribeFromMessages();
        }

        void SubscribeToMessages()
        {
            MessagingCenter.Subscribe<MainViewModel, string>(this, "GotoPage1", async (obj, p) =>
            {
                try
                {
                    string uri = "kash://page/1";
                    //DisplayAlert("Hi", "Must be App Linking to Handler Page 1", "Close");
                    var opened = await OpenAppService.LaunchAsync(uri);

                    if (!opened)
                    {
                        await DisplayAlert("Shit", $"Cannot open APP with URI {uri}", "Close");
                    }
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send<ContentPage, Exception>(this, "Error", ex);
                }
            });

            MessagingCenter.Subscribe<MainViewModel, string>(this, "GotoPage2", async (obj, p) =>
            {
                try
                {
                    string uri = "kash://page/2";
                    //DisplayAlert("Hi", "Must be App Linking to Handler Page 2", "Close");
                    var opened = await OpenAppService.LaunchAsync(uri);

                    if (!opened)
                    {
                        await DisplayAlert("Shit", $"Cannot open APP with URI {uri}", "Close");
                    }
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send<ContentPage, Exception>(this, "Error", ex);
                }
            });


            MessagingCenter.Subscribe<MainViewModel, Exception>(this, "Error", (obj, ex) =>
            {
                DisplayAlert("Shit", ex.ToString(), "Leave me alone");
            });
        }

        void UnsubscribeFromMessages()
        {
            MessagingCenter.Unsubscribe<MainViewModel, string>(this, "GotoPage1");
            MessagingCenter.Unsubscribe<MainViewModel, string>(this, "GotoPage2");
        }
    }
}