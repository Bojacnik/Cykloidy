using System;
using System.Collections.Generic;
using System.Drawing;

namespace CykloidyWPF
{
    class SimpleCycloid
    {
        double r = 1;      // radius of rolling circle
        double t;          // time parameter
        public double x, y;       // x and y coordinates of point on cycloid

        public SimpleCycloid(double radius, double x, double y)
        {
            this.r = radius;
        }

        public void Calculate()
        {
            x = r * (t / 100 - Math.Sin(t) + 30);
            y = r * (1 - Math.Cos(t)) + 50;
        }
    }
}
