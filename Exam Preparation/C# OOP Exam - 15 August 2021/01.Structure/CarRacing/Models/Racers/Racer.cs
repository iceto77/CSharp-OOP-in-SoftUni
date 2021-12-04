using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {

        }
        public string Username => throw new NotImplementedException();

        public string RacingBehavior => throw new NotImplementedException();

        public int DrivingExperience => throw new NotImplementedException();

        public ICar Car => throw new NotImplementedException();

        public bool IsAvailable()
        {
            throw new NotImplementedException();
        }

        public void Race()
        {
            throw new NotImplementedException();
        }
    }
}
