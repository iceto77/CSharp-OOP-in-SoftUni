using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquariums.Add(new FreshwaterAquarium(aquariumName));
                    break;
                case "SaltwaterAquarium":
                    aquariums.Add(new SaltwaterAquarium(aquariumName));
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }
        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case "Ornament":
                    decorations.Add(new Ornament());
                    break;
                case "Plant":
                    decorations.Add(new Plant());
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);         
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            this.aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(decoration);
            decorations.Remove(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish;
            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            if (this.aquariums.FirstOrDefault(x => x.Name == aquariumName).GetType().Name[0] == fishType[0])
            {
                this.aquariums.FirstOrDefault(x => x.Name == aquariumName).AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            return OutputMessages.UnsuitableWater;
        }
        public string FeedFish(string aquariumName)
        {
            this.aquariums.FirstOrDefault(x => x.Name == aquariumName).Feed();
            var currentAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var result = currentAquarium.Fish.Count;
            return string.Format(OutputMessages.FishFed,result);
        }
        public string CalculateValue(string aquariumName)
        {
            var currentAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var sum = currentAquarium.Fish.Sum(x => x.Price);
            sum += currentAquarium.Decorations.Sum(x => x.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, $"{sum:f2}");
        }
        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var item in this.aquariums)
            {
                sb.AppendLine(item.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
