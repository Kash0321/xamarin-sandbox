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
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
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
                    await Navigation.PushAsync(new Page1View());
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
                    await Navigation.PushAsync(new Page2View());
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