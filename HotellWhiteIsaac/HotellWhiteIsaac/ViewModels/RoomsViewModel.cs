using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.Views;

namespace HotellWhiteIsaac.ViewModels
{
    public class RoomsViewModel : BaseViewModel
    {
        public ObservableCollection<Room> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public RoomsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Room>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Room>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Room;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}