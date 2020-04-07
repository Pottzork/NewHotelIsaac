using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.ViewModels;

namespace HotellWhiteIsaac.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomsDetailPage : ContentPage
    {

        RoomsVM vm;  

        public RoomsDetailPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as RoomsVM;
        }

        public RoomsDetailPage(Room selectedProfile)
        {
            InitializeComponent();


            vm = Resources["vm"] as RoomsVM;
            vm.Room = selectedProfile;

        }

        private void ConfirmRoomButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewBookingPage());
        }

    }
}