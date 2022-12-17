using Data.Advanced.Implementations;
using Data.Basic.Implementations;

namespace Data.Simulation
{
    public class BasicCycloidSimulation
    {
        BasicCycloid bc = new BasicCycloid(
            new Circle(new Vector2(50, 50), 20),
            new Point(new Vector2(50-20, 50/2)),
            0D,
            1D
        );

        public void Step()
        {
            bc.Recalculate(1, 0);
        }

        public Circle getCircle()
        {
            return bc.circle;
        }
        public Point getPoint()
        {
            return bc.point;
        }
    }
}
