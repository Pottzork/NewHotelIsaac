using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HotellWhiteIsaac.ViewModels;
using HotellWhiteIsaac.Models;

namespace HotellWhiteIsaac.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomsPage : ContentPage
    {
        private Booking booking;

        public Booking Booking
        {
            get { return booking; }
            set
            {
                booking = value;
                TotalDays = booking.TotalDays;
                OnPropertyChanged("Booking");
            }
        }

        private int totalDays;

        public int TotalDays
        {
            get { return totalDays; }
            set { 
                Booking.TotalDays = totalDays;
            }
        }


        RoomsVM vm;

        public RoomsPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as RoomsVM;
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

        public void CalculateAmountOfDays()
        {
            TimeSpan timeSpan = CheckOutDate.Date - CheckInDate.Date;
            totalDays = timeSpan.Days;

        }

        private void CheckInDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            CalculateAmountOfDays();
        }

        private void CheckOutDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            CalculateAmountOfDays();
            TotalNightsLabel.Text = TotalDays.ToString();
        }

    }
}