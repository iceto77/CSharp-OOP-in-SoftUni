using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{

    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private readonly List<Item> items;
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => items;

        public void AddItem(Item item)
        {
            if ((this.Load + item.Weight) > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (items.FirstOrDefault(x => x.GetType().Name == name) == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            var itemToRemove = items.FirstOrDefault(x => x.GetType().Name == name);
            items.Remove(itemToRemove);
            return itemToRemove;
        }
    }
}