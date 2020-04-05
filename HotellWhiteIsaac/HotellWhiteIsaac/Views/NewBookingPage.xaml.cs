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
        public NewBookingPage()
        {
            InitializeComponent();
        }
    
    

        void Recalculate()
        {
            TimeSpan timeSpan = CheckOutDate.Date - CheckInDate.Date;
            TotalNightsLabel.Text = "TotalNights" + timeSpan.Days.ToString();
        }

        private void CheckInDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            Recalculate();
        }

        private void CheckOutDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            Recalculate();
        }
    }
}