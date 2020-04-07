using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.ViewModels.Helpers;
using HotellWhiteIsaac.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotellWhiteIsaac.ViewModels
{
    class NewBookingVM : INotifyPropertyChanged
    {
        //private Booking booking;

        //public Booking Booking
        //{
        //    get { return booking; }
        //    set
        //    {
        //        booking = value;
        //        Name = booking.Name;
        //        TotalDays = booking.TotalDays;
        //        extraBed = booking.ExtraBed;
        //        roomNumber = booking.RoomNumber;
        //        totalPrice = booking.TotalPrice;
        //        OnPropertyChanged("Booking");
        //    }
        //}

        private string name;
        public string Name
        {
            get { return name; }
            set { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private int totalDays;
        public int TotalDays
        {
            get { return totalDays; }
            set { 
                totalDays = value;
                OnPropertyChanged("TotalDays");
            }
        }

        private bool extraBed;

        public bool ExtraBed
        {
            get { return extraBed; }
            set { 
                extraBed = value;
                OnPropertyChanged("ExtraBed");
            }
        }

        private int roomNumber;

        public int RoomNumber
        {
            get { return roomNumber; }
            set { 
                roomNumber = value;
                OnPropertyChanged("RoomNumber");
            }
        }

        private float totalPrice;

        public float TotalPrice
        {
            get { return totalPrice; }
            set { 
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        public ICommand SaveBookingCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public NewBookingVM()
        {
            SaveBookingCommand = new Command(SaveBooking/*, SaveBookingCanExecute*/);
        }

        //private bool SaveBookingCanExecute(object arg)
        //{
        //    return !string.IsNullOrEmpty(Name);
        //    //Implementera så att bokningen inte har tomma "fields"
        //}

        private void SaveBooking(object obj)
        {
            bool result = DatabaseHelper.InsertBooking(new Booking
            {
                Name = Name,
                UserId = Auth.GetCurrentUserId(),
                BookDate = DateTime.Now,
                TotalDays = TotalDays,
                TotalPrice = TotalPrice,
                ExtraBed = ExtraBed,
                RoomNumber = RoomNumber
            });

            if (result)
            {
                App.Current.MainPage.DisplayAlert("Success!", "Thank you for your order\nYou will now be redirected to your profile page.", "ok");
                App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
            }
               
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
