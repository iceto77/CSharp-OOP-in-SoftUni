using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {

        }
        public string Make => throw new NotImplementedException();

        public string Model => throw new NotImplementedException();

        public string VIN => throw new NotImplementedException();

        public int HorsePower => throw new NotImplementedException();

        public double FuelAvailable => throw new NotImplementedException();

        public double FuelConsumptionPerRace => throw new NotImplementedException();

        public void Drive()
        {
            throw new NotImplementedException();
        }
    }
}
