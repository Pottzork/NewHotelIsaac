using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.ViewModels.Helpers;
using HotellWhiteIsaac.Views;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(HotellWhiteIsaac.Droid.Dependencies.Firestore))]
namespace HotellWhiteIsaac.Droid.Dependencies
{
    class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        List<Profile> profiles;
        List<Room> rooms;
        List<Booking> bookings;

        bool hasReadProfiles = false;
        bool hasReadRooms = false;
        bool hasReadBookings = false;

        public Firestore()
        {
            //Profile lista
            profiles = new List<Profile>();
            //Booking lista 
            bookings = new List<Booking>();
            //Rooms lista
            rooms = new List<Room>();
        }

        //<<<-----------PROFILE METODER---------------->>>

        public async Task<bool> DeleteProfile(Profile profile)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("profiles");
                collection.Document(profile.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool InsertProfile(Profile profile)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("profiles");
                var profileDocument = new Dictionary<string, Java.Lang.Object>
            {
                { "author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                { "name", profile.Name},
                { "isActive", profile.IsActive },
                { "subscribedDate", DateTimeToNativeDate(profile.SubscribedDate) }
            };

                collection.Add(profileDocument);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<IList<Profile>> ReadProfile()
        {
            hasReadProfiles = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("profiles");
            var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            //query.Get().AddOnCompleteListener(this);

            for (int i = 0; i < 35; i++)
            {
                await System.Threading.Tasks.Task.Delay(200);
                if (hasReadProfiles)
                {
                    break;
                }
            }
            return profiles;
        }

        public async Task<bool> UpdateProfile(Profile profile)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("profiles");
                collection.Document(profile.Id).Update("name", profile.Name, "isActive", profile.IsActive);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



        //<<<-----------RUM METODER---------------->>>

        public async Task<IList<Room>> ReadRoom()
        {
            hasReadRooms = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("rooms");
            var query = collection;
            query.Get().AddOnCompleteListener(this);

            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadRooms)
                {
                    break;
                }
            }
            return rooms;

        }

        //systemet hantera uppdatering av rummet efter varje gång någon bokar eller städar rummet
        public async Task<bool> UpdateRoom(Room room)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("rooms");
                collection.Document(room.Id).Update("isAvailable", room.IsAvailable, "extraBed", room.ExtraBed, "isCleaned", room.IsCleaned);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //läsa in alla rum som är tillgängliga
        public async Task<IList<Room>> ReadAvailableRooms()
        {
            hasReadRooms = false;
            //hämtar från collection där IsAvailable är true
            var query = Firebase.Firestore.FirebaseFirestore.Instance.Collection("rooms").WhereEqualTo("isAvailable", true);
            query.Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadBookings)
                {
                    break;
                }
            }
            return rooms;
        }



        //<<<-----------BOKNINGS METODER---------------->>>

        //Tar bort bokningar, kommer implementeras i Staff-Sida INTE customer/user
        public async Task<bool> DeleteBooking(Booking booking)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("bookings");
                collection.Document(booking.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



        //Funktion för att användaren ska kunna sätta in en bokning / Notera att detta hade kunnat göras för Staff också i senare version
        public bool InsertBooking(Booking booking)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("bookings");
                var bookingDocument = new Dictionary<string, Java.Lang.Object>
            {
                {"author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                {"totalDays", booking.TotalDays },
                {"extraBed", booking.ExtraBed },
                {"roomNumber", booking.RoomNumber},
                {"totalPrice", booking.TotalPrice},
                {"Booking created on: ", DateTimeToNativeDate(booking.BookDate) }
            };
                collection.Add(bookingDocument);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



        //Denna funktionen ska både customer och staff ha, just nu ser bara Customer sin egna
        //ska implementera funktion så staff kan läsa av ALLA bokningar också
        public async Task<IList<Booking>> ReadBooking()
        {
            hasReadBookings = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("bookings");

            //Gör så att customer kan se sina egna bokningar
            var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            query.Get().AddOnCompleteListener(this);

            //vad ska vi ha för length?

            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadBookings)
                {
                    break;
                }

            }
            return bookings;
        }



        //Hanteras av Staff/admin
        public async Task<bool> UpdateBooking(Booking booking)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("bookings");
                collection.Document(booking.Id).Update("name", booking.Name, "totalDays", booking.TotalDays,
                    "extraBed", booking.ExtraBed, "roomNumber", booking.RoomNumber, "totalPrice", booking.TotalPrice);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public void OnBookingComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;

                bookings.Clear();
                foreach (var doc in documents.Documents)
                {
                    Booking booking = new Booking
                    {
                        Name = doc.Get("name").ToString(),
                        TotalDays = (int)doc.Get("totalDays"),
                        ExtraBed = (bool)doc.Get("extraBed"),
                        RoomNumber = (int)doc.Get("roomNumber"),
                        TotalPrice = (float)doc.Get("totalPrice"),
                        Id = doc.Id,
                        BookDate = NativeDateToDateTime(doc.Get("bookDate") as Date)
                    };
                    bookings.Add(booking);
                }
            }
            else
            {
                bookings.Clear();
            }
            hasReadBookings = true;
        }



        //<<<-----------Datum METODER---------------->>>
        //Date kan implementeras i både booking och profile
        private static Date DateTimeToNativeDate(DateTime date)
        {
            long dateTimeUtcAsMilliseconds = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            return new Date(dateTimeUtcAsMilliseconds);
        }

        private static DateTime NativeDateToDateTime(Date date)
        {
            DateTime reference = System.TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));
            return reference.AddMilliseconds(date.Time);
        }



        //<<<-----------ON COMPLETE är kopplat till AddOnCompleteListener som en del metoder här använder---------------->>>

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;

                //profiles.Clear();
                rooms.Clear();

                foreach (var doc in documents.Documents)
                {
                    //Profile profile = new Profile
                    //{
                    //    IsActive = (bool)doc.Get("isActive"),
                    //    Name = doc.Get("name").ToString(),
                    //    UserId = doc.Get("author").ToString(),
                    //    SubscribedDate = NativeDateToDateTime(doc.Get("subscribedDate") as Date),
                    //    Id = doc.Id
                    //};

                    Room room = new Room
                    {
                        RoomType = doc.Get("roomType").ToString(),
                        Cost = (float)doc.Get("cost"),
                        IsAvailable = (bool)doc.Get("isAvailable")
                    };

                    //profiles.Add(profile);
                    rooms.Add(room);
                }
            }
            else
            {
                rooms.Clear();
                //profiles.Clear();
            }
            hasReadProfiles = true;
            hasReadRooms = true;
        }


    }
}