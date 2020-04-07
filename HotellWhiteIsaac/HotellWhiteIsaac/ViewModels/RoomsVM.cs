using HotellWhiteIsaac.Models;
using HotellWhiteIsaac.ViewModels.Helpers;
using HotellWhiteIsaac.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotellWhiteIsaac.ViewModels
{
    public class RoomsVM : INotifyPropertyChanged
    {
		private Room room;

		public Room Room
		{
			get { return room; }
			set { 
				room = value;
				IsAvailable = room.IsAvailable;
				IsCleaned = room.IsCleaned;
				ExtraBed = room.ExtraBed;
				RoomType = room.RoomType;
				Cost = room.Cost;
				OnPropertyChanged("Room");
				}
			//Insert ID  Firestore/db.collection('rooms').doc('room1-10').get();

		}

		private Room selectedRoom;

		public Room SelectedRoom
		{
			get { return selectedRoom; }
			set { 
				selectedRoom = value;
				OnPropertyChanged("SelectedRoom");
				if (selectedRoom != null)
				{
					App.Current.MainPage.Navigation.PushAsync(new RoomsDetailPage(selectedRoom));
				}
			}
		}

		public ObservableCollection<Room> Rooms { get; set; }

		public RoomsVM()
		{
			UpdateRoomCommand = new Command(UpdateRoom);
			Rooms = new ObservableCollection<Room>();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private string id;

		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		private string roomType;

		public string RoomType
		{
			get { return roomType; }
			set {
				roomType = value;
				Room.RoomType = roomType;
				OnPropertyChanged("RoomType");
			}
		}
		private float cost;

		public float Cost
		{
			get { return cost; }
			set { cost = value;
				Room.Cost = cost;
				OnPropertyChanged("Cost");
					}
		}

		private bool isAvailable;

		public bool IsAvailable
		{
			get { return isAvailable; }
			set { isAvailable = value; OnPropertyChanged("IsAvailable"); }
		}

		private bool isCleaned;

		public bool IsCleaned
		{
			get { return isCleaned; }
			set { isCleaned = value; }
		}

		private bool extraBed;

		public bool ExtraBed
		{
			get { return extraBed; }
			set { extraBed = value; OnPropertyChanged("ExtraBed"); }
		}



		public ICommand UpdateRoomCommand { get; set; }



		public async void ReadRooms()
		{
			var rooms = await DatabaseHelper.ReadRoom();

			Rooms.Clear();
			foreach (var r in rooms)
			{
				Rooms.Add(r);
			}
		}

		//Behövs detta verkligne eftersom den hanterar endast room update message och hantering som kopplas till en binding?
		private async void UpdateRoom(object obj)
		{
			bool result = await DatabaseHelper.UpdateRoom(Room);
			if (result)
			{
				await App.Current.MainPage.Navigation.PopAsync();
			}
			else
			{
				await App.Current.MainPage.DisplayAlert("Error", "there was an error, please try again", "Ok");
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
