using System;
using Xamarin.Forms;

namespace HotellWhiteIsaac.Models
{
    public class Room
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string RoomType { get; set; }
        public float Cost { get; set; }
        public bool IsAvailable { get; set; }
        public bool ExtraBed { get; set; }
        public bool IsCleaned { get; set; }
        public Button BookButton { get; set; }
    }
}