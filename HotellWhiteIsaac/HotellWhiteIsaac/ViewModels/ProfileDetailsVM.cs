using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotellWhiteIsaac.ViewModels
{
    class ProfileDetailsVM : INotifyPropertyChanged
    {
        private Profile profile;

        public Profile Profile
        {
            get { return profile; }
            set { 
                profile = value;
                Name = profile.Name;
                IsActive = profile.IsActive;
                OnPropertyChanged("Profile");
            
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                Profile.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Profile");
            }
        }

        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; Profile.IsActive = isActive; OnPropertyChanged("IsActive"); OnPropertyChanged("Profile"); }
        }



        public ICommand UpdateCommand{ get; set; }
        public ICommand DeleteCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public ProfileDetailsVM()
        {
            UpdateCommand = new Command(Update, UpdateCanExecute);
            DeleteCommand = new Command(Delete);
        }

        private bool UpdateCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private async void Update(object parameter)
        {
            bool result = await DatabaseHelper.UpdateProfile(Profile);
            if (result)
            {
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("ERROR", "There was an error, please try again", "ok");
            }
        }

        private async void Delete(object parameter)
        {
            bool result = await DatabaseHelper.DeleteProfile(Profile);
            if (result)
            {
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("ERROR", "There was an error, please try again", "ok");
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
