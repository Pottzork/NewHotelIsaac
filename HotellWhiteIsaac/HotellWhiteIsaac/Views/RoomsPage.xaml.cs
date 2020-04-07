using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HotellWhiteIsaac.ViewModels;

namespace HotellWhiteIsaac.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomsPage : ContentPage
    {

        RoomsVM vm;
        NewBookingVM nb;


        public RoomsPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as RoomsVM;
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

        public int Recalculate()
        {
            TimeSpan timeSpan = CheckOutDate.Date - CheckInDate.Date;
            return timeSpan.Days;

        }

        private void CheckInDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            Recalculate();
        }

        private void CheckOutDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            Recalculate();
            TotalNightsLabel.Text = Recalculate().ToString();
        }

    }
}