using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HotellWhiteIsaac.ViewModels
{
    public class AboutViewModel
    {
        public AboutViewModel()
        {

            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
            OpenTermsOfAgreementWebCommand = new Command(async () => await Browser.OpenAsync("https://www.gdprprivacynotice.com/sample-terms-conditions/terms-conditions-using-services-clause-example.jpg"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenTermsOfAgreementWebCommand { get; }
    }
}