﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotellWhiteIsaac.Models
{
    public class Profile
    {

        public string Id { get; set; }

        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime SubscribedDate { get; set; }
        public bool IsActive { get; set; }



    }
}
