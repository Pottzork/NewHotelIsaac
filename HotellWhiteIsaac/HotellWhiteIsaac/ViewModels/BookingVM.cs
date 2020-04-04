using HotellWhiteIsaac.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace HotellWhiteIsaac.ViewModels
{
    class BookingVM : INotifyPropertyChanged
    {
        private Booking booking;

        public Booking Booking
        {
            get { return booking; }
            set
            {
                booking = value;
                Name = booking.Name;
                TotalDays = booking.TotalDays;
                extraBed = booking.ExtraBed;
                roomNumber = booking.RoomNumber;
                totalPrice = booking.TotalPrice;
                OnPropertyChanged("Booking");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                booking.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Profile");
            }
        }

        private int totalDays;

        public int TotalDays
        {
            get { return totalDays; }
            set { 
                totalDays = value;
                booking.TotalDays = totalDays;
                OnPropertyChanged("TotalDays");
                OnPropertyChanged("Profile");
            }
        }

        private bool extraBed;

        public bool ExtraBed
        {
            get { return extraBed; }
            set { 
                extraBed = value;
                booking.ExtraBed = extraBed;
                OnPropertyChanged("ExtraBed");
                OnPropertyChanged("Profile");
            }
        }

        private int roomNumber;

        public int RoomNumber
        {
            get { return roomNumber; }
            set { 
                roomNumber = value;
                booking.RoomNumber = roomNumber;
                OnPropertyChanged("RoomNumber");
                OnPropertyChanged("Profile");
            }
        }

        private decimal totalPrice;

        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { 
                totalPrice = value;
                booking.TotalPrice = totalPrice;
                OnPropertyChanged("TotalPrice");
                OnPropertyChanged("Profile");
            }
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public BookingVM()
        {
            
        }

        private async void Update(object parameter)
        {
            
        }

        //Detta komm inte implementeras till User/Customer, denna funktionen finns här för att Staff ska kunna komma åt datan för att sedan Delete-a
        private async void Delete(object parameter)
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
