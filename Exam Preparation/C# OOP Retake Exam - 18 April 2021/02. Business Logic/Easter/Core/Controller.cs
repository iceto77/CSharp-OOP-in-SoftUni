using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private int coloredEggs;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            coloredEggs = 0;
    }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            switch (bunnyType)
            {
                case "HappyBunny":
                    this.bunnies.Add(new HappyBunny(bunnyName));
                    break;
                case "SleepyBunny":
                    this.bunnies.Add(new SleepyBunny(bunnyName));
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            if (this.bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            IDye dye = new Dye(power);
            this.bunnies.FindByName(bunnyName).AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            eggs.Add(new Egg(eggName, energyRequired));
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var workshop = new Workshop();
            var sortedBunnyes = bunnies.Models.Where(y => y.Energy >= 50).ToList();
            var anyBunnyReady = sortedBunnyes.Count > 0;

            if (!anyBunnyReady)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            var egg = eggs.Models.First(x => x.Name == eggName);

            foreach (var bunny in bunnies.Models.Where(y => y.Energy >= 50).OrderByDescending(x => x.Energy).ToList())
            {
                workshop.Color(egg, bunny);

                if (egg.IsDone())
                {
                    break;
                }


                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }

            }
            if (egg.IsDone())
            {
                coloredEggs++;
                return $"Egg {egg.Name} is done.";
            }
            else
            {
                return $"Egg {egg.Name} is not done.";
            }

        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var item in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {item.Name}");
                sb.AppendLine($"Energy: {item.Energy}");
                int numOfDyes = 0;
                foreach (var dye in item.Dyes)
                {
                    if (!dye.IsFinished())
                    {
                        numOfDyes++;
                    }
                }
                sb.AppendLine($"Dyes: {numOfDyes} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
