using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.ViewModels.Helpers;
using HotellWhiteIsaac.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace HotellWhiteIsaac.ViewModels
{
    public class ProfilesVM : INotifyPropertyChanged
    {

        private Profile selectedProfile;

        public Profile SelectedProfile
        {
            get { return selectedProfile; }
            set { 
                selectedProfile = value; 
                OnPropertyChanged("SelectedProfile");
                if (selectedProfile != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new ProfileDetailsPage(selectedProfile));
                }
            }
        }

        public ObservableCollection<Profile> Profiles { get; set; }

        public ProfilesVM()
        {
            Profiles = new ObservableCollection<Profile>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadProfiles()
        {
            var profiles = await DatabaseHelper.ReadProfile();

            Profiles.Clear();
            foreach (var p in profiles)
            {
                Profiles.Add(p);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
