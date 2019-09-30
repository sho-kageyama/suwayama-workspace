using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using XDemo.Views;

namespace XDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        void TimerCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new TimerView());
        }

        void MemoCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new MemoView(),true);
        }

        void PaintCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new PaintView());
        }


        public MainPage()
        {
            InitializeComponent();
            Navigation.PushModalAsync(new FirstView(),true);
            SetTimer();
            Connectivity.ConnectivityChanged += CheckNetworkState;
        }

        void SetTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Navigation.PopModalAsync(true);
                return false;
            });

        }

        void CheckNetworkState(object s, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            if (access == NetworkAccess.Internet)
            {
                DisplayAlert("state", "online", "OK");
            }
            else if (access == NetworkAccess.None)
            {
                DisplayAlert("state", "offline", "OK");
            }
        }
    }
    

}
