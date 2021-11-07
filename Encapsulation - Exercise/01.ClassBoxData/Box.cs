using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double heigth)
        {
            Length = length;
            Width = width;
            Height = heigth;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                CheckNegativValue(value, nameof(Length));
                this.length = value;
            }
        }


        public double Width
        {
            get => this.width;
            private set
            {
                CheckNegativValue(value, nameof(Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                CheckNegativValue(value, nameof(Height));
                this.height = value;
            }
        }
        public double SurfaceArea()
        {
            return (2 * length * width + 2 * length * height + 2 * width * height);
        }
        public double LateralSurfaceArea()
        {
            return (2 * length * height + 2 * width * height);
        }
        public double Volume()
        {
            return (length * height * width);
        }
        private void CheckNegativValue(double value, string valName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{valName} cannot be zero or negative.");
            }
        }

    }
}
