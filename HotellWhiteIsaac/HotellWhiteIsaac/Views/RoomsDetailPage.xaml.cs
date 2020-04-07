using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.ViewModels;

namespace HotellWhiteIsaac.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RoomsDetailPage : ContentPage
    {
        RoomsDetailViewModel viewModel;

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

            //var item = new Room
            //{
            //    Text = "Item 1",
            //    Description = "This is an item description."
                
            //};

            //var bookButton = new Button
            //{
            //    Text = "Book Now"
            //};

            //viewModel = new RoomsDetailViewModel(item, bookButton);
            //BindingContext = viewModel;
        }

        private void ConfirmRoomButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewBookingPage());
        }
    }
}