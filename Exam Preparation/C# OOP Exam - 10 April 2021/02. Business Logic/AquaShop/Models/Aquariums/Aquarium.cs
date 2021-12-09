using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        //private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fishes;
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }
        public int Capacity { get; }
        //o	The number of Fish аn Aquarium can have

        public ICollection<IDecoration> Decorations => this.decorations;
        public ICollection<IFish> Fish => this.fishes;
        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public void AddFish(IFish fish)
        {
            if (fishes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            fishes.Add(fish);
        }
        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }
        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }
        public void Feed()
        {
            foreach (var item in fishes)
            {
                item.Eat();
            }
        }
        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (fishes.Count == 0)
            {
                sb.AppendLine($"Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.fishes.Select(x => x.Name))}");
            }
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }


    }
}
