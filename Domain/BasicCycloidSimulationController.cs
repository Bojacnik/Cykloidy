using Data.Simulation;

namespace Domain
{
    public class BasicCycloidSimulationController
    {
        BasicCycloidSimulation bcs = new BasicCycloidSimulation();
        
        public void Run()
        {
            bcs.Step();
        }
    }
}
