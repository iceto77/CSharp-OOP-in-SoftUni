using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        public Driver(string name)
        {
        }

        public string Name => throw new NotImplementedException();

        public ICar Car => throw new NotImplementedException();

        public int NumberOfWins => throw new NotImplementedException();

        public bool CanParticipate => throw new NotImplementedException();

        public void AddCar(ICar car)
        {
            throw new NotImplementedException();
        }

        public void WinRace()
        {
            throw new NotImplementedException();
        }
    }
}
