using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotellWhiteIsaac.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotellWhiteIsaac.Views.CleanerView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnassignedPage : ContentPage
    {
        RoomsVM vm;
        public UnassignedPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as RoomsVM; 
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadRooms();
        }
    }
}