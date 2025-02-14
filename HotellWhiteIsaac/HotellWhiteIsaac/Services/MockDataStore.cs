﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotellWhiteIsaac.Models;

namespace HotellWhiteIsaac.Services
{
    public class MockDataStore : IDataStore<Room>
    {
        readonly List<Room> items;

        public MockDataStore()
        {
            items = new List<Room>()
            {
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 1", Description="Single room with ocean view.\nPrice: 800 SEK / night"},
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 2", Description="Single room with ocean view.\nPrice: 800 SEK / night" },
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 3", Description="Double room with 2 bathrooms.\nPrice: 1100 SEK / night" },
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 4", Description="Double room with 1 bathroom and ocean view.\nPrice: 1100 SEK / night" },
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 5", Description="This is an item description." },
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 6", Description="This is an item description." },
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 7", Description="This is an item description." },
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 8", Description="This is an item description." },
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 9", Description="This is an item description." },
                new Room { Id = Guid.NewGuid().ToString(), Text = "Room 10", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Room item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Room item)
        {
            var oldItem = items.Where((Room arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Room arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Room> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Room>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}