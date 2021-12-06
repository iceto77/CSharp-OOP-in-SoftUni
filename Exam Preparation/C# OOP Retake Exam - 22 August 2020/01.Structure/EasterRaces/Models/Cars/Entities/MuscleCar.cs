using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower) 
            : base(model, horsePower, 5000, 400, 600)
        {
        }
    }
}
