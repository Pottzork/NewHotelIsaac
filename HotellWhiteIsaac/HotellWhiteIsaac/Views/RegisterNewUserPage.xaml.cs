using HotellWhiteIsaac.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotellWhiteIsaac.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterNewUser : ContentPage
    {
        public RegisterNewUser()
        {
            InitializeComponent();
        }

        private void OnAlreadyHaveAccount_Tapped(object sender, EventArgs e)
        {
            RegisterStackLayout.IsVisible = false;
            LoginStackLayout.IsVisible = true;

        }

        private void OnDontHaveAccount_Tapped(object sender, EventArgs e)
        {
            RegisterStackLayout.IsVisible = true;
            LoginStackLayout.IsVisible = false;

        }
    }
}