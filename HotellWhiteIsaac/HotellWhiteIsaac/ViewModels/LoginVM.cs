using HotellWhiteIsaac.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HotellWhiteIsaac.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; 
                OnPropertyChanged("Name");
                OnPropertyChanged("CanRegister");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; 
                OnPropertyChanged("Email");
                OnPropertyChanged("CanLogin");
                OnPropertyChanged("CanRegister");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; 
                OnPropertyChanged("Password");
                OnPropertyChanged("CanLogin");
                OnPropertyChanged("CanRegister");
            }          
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; 
                OnPropertyChanged("ConfirmPassword");
                OnPropertyChanged("CanRegister");
            }
            
        }

     

        public bool CanLogin
        {
            get { return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password); }
        }

        public bool CanRegister
        {

            get { return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword) && !string.IsNullOrEmpty(Name); }
        }



        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public LoginVM()
        {
            LoginCommand = new Command(Login, LoginCanExecute);
            RegisterCommand = new Command(Register, RegisterCanExecute);
            OpenFacebookLogin = new Command(async () => await Browser.OpenAsync("https://www.facebook.com/"));
            OpenGoogleLogin = new Command(async () => await Browser.OpenAsync("https://accounts.google.com/"));
        }
        public ICommand OpenFacebookLogin { get; }
        public ICommand OpenGoogleLogin { get; }

        private bool RegisterCanExecute(object parameter)
        {
            return CanRegister;
        }

        private async void Register(object parameter)
        {
            if (ConfirmPassword != Password)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "Ok");
            }
            else
            {
                bool result = await Auth.RegisterUser(Name, Email, Password);
                if (result)
                {
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }
           
        }

        private async void Login(object parameter)
        {
            bool result = await Auth.AuthenticateUser(Email, Password);
            if (result)
            {
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private bool LoginCanExecute(object parameter)
        {
            return CanLogin;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
