using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HotellWhiteIsaac.Services;
using HotellWhiteIsaac.Views;

namespace HotellWhiteIsaac
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new NewBookingPage());


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
