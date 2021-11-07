﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public interface IDrawable
    {
        void Draw();

    }

    class Circle : IDrawable
    {


        public Circle(int radius)
        {
            this.Radius = radius;
        }

        private int radius;

        public int Radius
        {
            get => radius;
            private set
            {
                radius = value;
            }
        }


        public void Draw()
        {
            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;
            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
