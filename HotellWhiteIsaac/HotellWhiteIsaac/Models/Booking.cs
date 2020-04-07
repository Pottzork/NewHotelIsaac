using System;
using System.Collections.Generic;
using System.Text;

namespace HotellWhiteIsaac.Models
{
  public class Booking
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int TotalDays { get; set; }
        public bool ExtraBed { get; set; }
        public int RoomNumber { get; set; }
        public float TotalPrice { get; set; }
        public DateTime BookDate { get; set; }
    }
}
