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
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(HotellWhiteIsaac.Droid.Dependencies.Firestore))]
namespace HotellWhiteIsaac.Droid.Dependencies
{
    class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        
        List<Profile> profiles;
        bool hasReadProfiles = false;

        public Firestore()
        {
            profiles = new List<Profile>();
        }
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
            query.Get().AddOnCompleteListener(this);

            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
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

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;

                profiles.Clear();
                foreach (var doc in documents.Documents)
                {
                    Profile profile = new Profile
                    {
                        IsActive = (bool)doc.Get("isActive"),
                        Name = doc.Get("name").ToString(),
                        UserId = doc.Get("author").ToString(),
                        SubscribedDate = NativeDateToDateTime(doc.Get("subscribedDate") as Date),
                        Id = doc.Id
                    };

                    profiles.Add(profile);
                }
            }
            else
            {
                profiles.Clear();
            }
            hasReadProfiles = true;
        }
    }
}