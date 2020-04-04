using HotellWhiteIsaac.Models;
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
    public partial class ProfileDetailsPage : ContentPage
    {

        ProfileDetailsVM vm;

        public ProfileDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as ProfileDetailsVM;
        }

        public ProfileDetailsPage(Profile selectedProfile)
        {
            InitializeComponent();

            vm = Resources["vm"] as ProfileDetailsVM;
            vm.Profile = selectedProfile;
        }
    }
}