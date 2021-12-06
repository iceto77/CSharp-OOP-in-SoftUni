using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        public Race(string name, int laps)
        {

        }

        public string Name => throw new NotImplementedException();

        public int Laps => throw new NotImplementedException();

        public IReadOnlyCollection<IDriver> Drivers => throw new NotImplementedException();

        public void AddDriver(IDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
