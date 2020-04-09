using HotellWhiteIsaac.ViewModels;
using HotellWhiteIsaac.ViewModels.Helpers;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotellWhiteIsaac.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {

        ProfilesVM vm;
        public ProfilePage()
        {
            InitializeComponent();

            vm = Resources["vm"] as ProfilesVM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!Auth.IsAuthenticated())
            {
                await Task.Delay(400); //Delay så att man inte ser profilepage om man ej är authenticated
                await Navigation.PushAsync(new RegisterNewUser());
            }
            else
            {
                vm.ReadProfiles();
            }
        }

        private void ShowAvailableRoomsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RoomsPage());
        }

        private void UpdateInfoButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("INFO!", "This function is still under progress. Make sure to check it out later.", "OK");
        }
    }
}