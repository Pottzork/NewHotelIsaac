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
        bool InsertBooking(Booking booking);
        Task<bool> DeleteBooking(Booking booking);
        Task<bool> UpdateBooking(Booking booking);
        Task<IList<Booking>> ReadBooking();
        //-----------------------------------
        //Room hantering
        Task<bool> UpdateRoom(Room room);
        Task<IList<Room>> ReadRoom();
        Task<IList<Room>> ReadAvailableRooms();

        
  
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

        public static Task<bool> DeleteBooking(Booking booking)
        {
            return firestore.DeleteBooking(booking);
        }
        public static bool InsertBooking(Booking booking)
        {
            return firestore.InsertBooking(booking);
        }

        public static Task<IList<Booking>> ReadBooking()
        {
            return firestore.ReadBooking();
        }
        
        public static Task<bool> UpdateBooking(Booking booking)
        {
            return firestore.UpdateBooking(booking);
        }


        //              Här hanteras Room
        //-----------------------------------------------------------------------

        public static Task<bool> UpdateRoom(Room room)
        {
            return firestore.UpdateRoom(room);
        }
       public static Task<IList<Room>> ReadRoom()
        {
            return firestore.ReadRoom();
        }
       public static Task<IList<Room>> ReadAvailableRooms()
        {
            return firestore.ReadAvailableRooms();
        }

    }
}
