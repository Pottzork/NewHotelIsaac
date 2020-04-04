using HotellWhiteIsaac.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotellWhiteIsaac.ViewModels
{
    public class NewProfileVM : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; OnPropertyChanged("IsActive"); }
        }

        public ICommand SaveProfileCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewProfileVM()
        {
            SaveProfileCommand = new Command(SaveProfile, SaveProfileCanExecute);
        }

        private bool SaveProfileCanExecute(object arg)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void SaveProfile(object obj)
        {
            bool result = DatabaseHelper.InsertProfile(new Models.Profile
            {
                IsActive = IsActive,
                Name = Name,
                UserId = Auth.GetCurrentUserId(),
                SubscribedDate = DateTime.Now
            });

            if (result)
            {
                App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "ok");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
