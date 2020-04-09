using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotellWhiteIsaac.ViewModels.Helpers
{

    public interface IAuth
    {
        Task<bool> RegisterUser(string name, string email, string password);
        Task<bool> AuthenticateUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
    }

    public class Auth
    {
        private static IAuth auth = DependencyService.Get<IAuth>();

        public static async Task<bool> RegisterUser(string name, string email, string password)
        {
            try
            {
                return await auth.RegisterUser(name, email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "Ok");
                return false;
            }
        }

        public static async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {
                bool hasLoggedIn = await auth.AuthenticateUser(email, password);
                if (hasLoggedIn == true)
                {
                    await App.Current.MainPage.DisplayAlert("Login successfully","You are now beeing redirected to your profile page.", "Ok");
                }
                return hasLoggedIn;
            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "Ok");
                return false;
            }
        }

        public static bool IsAuthenticated()
        {
            return auth.IsAuthenticated();
        }
        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }
    }
}
