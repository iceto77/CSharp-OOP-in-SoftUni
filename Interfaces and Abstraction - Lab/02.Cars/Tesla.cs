using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int  battery;

        public Tesla(string model, string color, int battery)
        {
            this.model = model;
            this.color = color;
            this.battery = battery;
        }

        public string Model => this.model;

        public string Color => this.color;

        public int Battery => this.battery;

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().TrimEnd();
            //Grey Seat Leon
        }
    }
}
