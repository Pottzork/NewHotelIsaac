using System;

using HotellWhiteIsaac.Models;

namespace HotellWhiteIsaac.ViewModels
{
    public class RoomsDetailViewModel : BaseViewModel
    {
        public Room Item { get; set; }
        public RoomsDetailViewModel(Room item = null, Xamarin.Forms.Button bookButton = null)
        {
            Title = item?.Text;
            Item = item;
            
        }
    }
}
