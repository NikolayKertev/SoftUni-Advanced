namespace Vehicles
{
    using Core.Interfaces;
    using Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

/*
Car 30 0.04 10
Truck 100 0.5 300
Bus 100 1 200
*/
