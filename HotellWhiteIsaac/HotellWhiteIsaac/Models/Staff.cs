using System;
using System.Collections.Generic;
using System.Text;

namespace HotellWhiteIsaac.Models
{
    class Staff
    {
        public int Id { get; set; } //Hämtar current user UID
        public string Name { get; set; }    //Namnet på personen
        public int DepartmentId { get; set; }   //I fields för att känna av vilken sida man ska hamna på
  
    }
}
