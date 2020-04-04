using HotellWhiteIsaac.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotellWhiteIsaac.ViewModels.Helpers
{

    public interface IFirestore
    {
        //Profile hantering
        bool InsertProfile(Profile profile);
        Task<bool> DeleteProfile(Profile profile);
        Task<bool> UpdateProfile(Profile profile);
        Task<IList<Profile>> ReadProfile();
        //-----------------------------------
        //Booking hantering
  
    }
    public class DatabaseHelper 
    {
        private static IFirestore firestore = DependencyService.Get<IFirestore>();

        //              Här hanteras Profile
        //-----------------------------------------------------------------------
       
        public static Task<bool> DeleteProfile(Profile profile)
        {
            return firestore.DeleteProfile(profile);
        }

        public static bool InsertProfile(Profile profile)
        {
            return firestore.InsertProfile(profile);
        }

        public static Task<IList<Profile>> ReadProfile()
        {
            return firestore.ReadProfile();
        }

        public static Task<bool> UpdateProfile(Profile profile)
        {
            return firestore.UpdateProfile(profile);
        }

        //              Här hanteras Booking
        //-----------------------------------------------------------------------


    }
}
