using HotellWhiteIsaac.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotellWhiteIsaac.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {

        RoomsVM vm;
        public AboutPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as RoomsVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.ReadRooms();
        }
    }
}