using Data.Simulation;

namespace Domain
{
    public class BasicCycloidSimulationController
    {
        public readonly BasicCycloidSimulation bcs;

        public BasicCycloidSimulationController(double stredX, double stredY, double radius, double pointX, double pointY, double offset, double angle)
        {
            this.bcs = new BasicCycloidSimulation(stredX, stredY, radius, pointX, pointY, offset, angle);
        }

        public void Run()
        {
            bcs.Step();

        }

        private void setup()
        {
        }


    }
}
