using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        public SportsCar(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower) 
            : base(model, horsePower, 3000, 250, 450)
        {
        }
    }
}
