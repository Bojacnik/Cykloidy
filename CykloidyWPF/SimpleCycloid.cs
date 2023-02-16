using System;
using System.Collections.Generic;

namespace CykloidyWPF
{
    class SimpleCycloid
    {
        double r = 1;      // radius of rolling circle
        public double x, y;       // x and y coordinates of point on cycloid

        public SimpleCycloid(double radius, double x, double y)
        {
            this.r = radius;
            this.x = x;
            this.y = y;
        }

        private List<PointD> GetCycloidPoints()
        {
            List<PointD> points = new List<PointD>();

            double step = 360D;
            double stepsTaken = 0D;

            double a = r;
            double x, y;

            while (stepsTaken < 360)
            {
                x = step * a * ((stepsTaken / 100) - Math.Sin(stepsTaken * (Math.PI / 180D)));
                y = step * a * (1 - Math.Cos(stepsTaken * (Math.PI / 180D)));
                points.Add(new PointD(x, y));
                stepsTaken += 1;
            }

            return points;
        }
    }
}
