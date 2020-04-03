using System;

using HotellWhiteIsaac.Models;

namespace HotellWhiteIsaac.ViewModels
{
    public class RoomsDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public RoomsDetailViewModel(Item item = null, Xamarin.Forms.Button bookButton = null)
        {
            Title = item?.Text;
            Item = item;
            
        }
    }
}
