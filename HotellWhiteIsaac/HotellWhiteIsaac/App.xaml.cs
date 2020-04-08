using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HotellWhiteIsaac.Services;
using HotellWhiteIsaac.Views;
using HotellWhiteIsaac.Views.CleanerView;

namespace HotellWhiteIsaac
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new ProfilePage())
            {
                BarBackgroundColor = Color.FromHex("#0f0f0f"),
                BarTextColor = Color.White
            };


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
