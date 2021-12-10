using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Models.Mission.Contracts;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronauts;
        private readonly IRepository<IPlanet> planets;
        private readonly IMission goToPlanet;
        private int exploredPlanetsCount;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            goToPlanet = new Mission();
            this.exploredPlanetsCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            switch (type)
            {
                case "Biologist":
                    this.astronauts.Add(new Biologist(astronautName));
                    break;
                case "Geodesist":
                    this.astronauts.Add(new Geodesist(astronautName));
                    break;
                case "Meteorologist":
                    this.astronauts.Add(new Meteorologist(astronautName));
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var newPlanet = new Planet(planetName);
            foreach (var item in items)
            {
                newPlanet.Items.Add(item);
            }
            this.planets.Add(newPlanet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }
        public string RetireAstronaut(string astronautName)
        {
            var astronautToRetire = this.astronauts.FindByName(astronautName);
            if (astronautToRetire == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            this.astronauts.Remove(astronautToRetire);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            /*
            int deadAstronauts = this.astronauts.Models.Count;
            Mission goToPlanet = new Mission();
            var targetPlanet = this.planets.FindByName(planetName);
            var astronautsForMision = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            if (astronautsForMision.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            goToPlanet.Explore(targetPlanet, astronautsForMision);
            exploredPlanetsCount++;
            deadAstronauts -= this.astronauts.Models.Count;
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
            */

            var astronautsForMision = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            if (astronautsForMision.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            var targetPlanet = this.planets.FindByName(planetName);
            int deadAstronauts = 0;
            this.goToPlanet.Explore(targetPlanet, astronautsForMision);
            exploredPlanetsCount++;
            foreach (var current in astronautsForMision)
            {
                if (!current.CanBreath)
                {
                    deadAstronauts++;
                }
            }
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var item in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {item.Name}");
                sb.AppendLine($"Oxygen: {item.Oxygen}");
                string info = item.Bag.Items.Any() ?
                    string.Join(", ", item.Bag.Items) :
                    "none";
                    sb.AppendLine($"Bag items: {info}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
