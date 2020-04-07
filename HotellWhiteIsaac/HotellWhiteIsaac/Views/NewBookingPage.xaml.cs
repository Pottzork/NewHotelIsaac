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
    public partial class NewBookingPage : ContentPage
    {
        RoomsPage rp;
        public NewBookingPage()
        {
            InitializeComponent();
        }
    
        private void TermsOfService_Tapped(object sender, EventArgs e)
        {
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Recalculate();
        }
        private void TermsChecbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ConfirmButton.BackgroundColor = Color.LightGreen;
        }

        //void Recalculate()
        //{
        //    TotalDaysLabel.Text = rp.Recalculate().ToString();
        //}
    }
}