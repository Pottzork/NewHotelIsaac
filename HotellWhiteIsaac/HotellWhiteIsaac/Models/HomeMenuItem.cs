using System;
using System.Collections.Generic;
using System.Text;

namespace HotellWhiteIsaac.Models
{
    public enum MenuItemType
    {
        Browse,
        Signin,
        Register,
        About

    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
