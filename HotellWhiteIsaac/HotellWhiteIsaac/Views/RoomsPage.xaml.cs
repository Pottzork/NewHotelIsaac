using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.Views;
using HotellWhiteIsaac.ViewModels;

namespace HotellWhiteIsaac.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RoomsPage : ContentPage
    {
        RoomsViewModel viewModel;
        RoomsVM vm;

        public RoomsPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as RoomsVM;
            BindingContext = viewModel = new RoomsViewModel();
        }


        //async void OnItemSelected(object sender, EventArgs args)
        //{
        //    var layout = (BindableObject)sender;
        //    var item = (Room)layout.BindingContext;
        //    await Navigation.PushAsync(new RoomsDetailPage(new RoomsVM(item)));
        //}

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.ReadRooms();
        }

        private void ShowAvailableRommsButton_Clicked(object sender, EventArgs e)
        {
            RoomsStackLayout.IsVisible = true;
            PickDateStackLayout.IsVisible = false;
        }

        void Recalculate()
        {
            TimeSpan timeSpan = CheckOutDate.Date - CheckInDate.Date;
            TotalNightsLabel.Text = timeSpan.Days.ToString();
        }

        private void CheckInDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            Recalculate();
        }

        private void CheckOutDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            Recalculate();
        }

    }
}