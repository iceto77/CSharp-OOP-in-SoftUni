using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {
        }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Count > 0)
                {
                    var findedItem = planet.Items.FirstOrDefault();
                    astronaut.Bag.Items.Add(findedItem);
                    planet.Items.Remove(findedItem);
                    astronaut.Breath();
                }
                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
