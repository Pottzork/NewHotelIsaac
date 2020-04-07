using HotellWhiteIsaac.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HotellWhiteIsaac.ViewModels
{
    class RoomDetailsVM : INotifyPropertyChanged
    {


		private Room room;

		public Room Room
		{
			get { return room; }
			set { 
				room = value;

					}
		}

		private int myVar;

		public int MyProperty
		{
			get { return myVar; }
			set { myVar = value; }
		}



		public event PropertyChangedEventHandler PropertyChanged;
	}
}
