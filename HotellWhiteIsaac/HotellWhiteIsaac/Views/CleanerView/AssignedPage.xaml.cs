using HotellWhiteIsaac.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotellWhiteIsaac.Views.CleanerView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignedPage : ContentPage
    {
        RoomsVM vm;

        public AssignedPage()
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