using Domain.Basic.Interfaces;
using Domain.Primitives.Abstractions;
using Domain.Primitives.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Basic.Implementations
{
    public class BasicPusher : IBasicPusher
    {
        List<Geometry> geometries;
        double pushValue;

        public BasicPusher(List<Geometry> geometries, double pushvalue)
        {
            this.geometries = geometries;
            pushValue = pushvalue;
        }

        public void Step()
        {
            foreach (Geometry g in geometries)
            {
                if (g is Circle c)
                    c.Push(pushValue, 0);
            }
        }
    }
}
