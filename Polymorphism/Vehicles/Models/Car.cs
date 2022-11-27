namespace Vehicles.Models
{
    using Vehicles.Models.Interfaces;
    public class Car : Vehicle
    {
        private const double CAR_CONSUMPTION_MULTIPLIER = 0.9;
        private const double CAR_REFUEL_MULTIPLIER = 1;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, CAR_CONSUMPTION_MULTIPLIER, CAR_REFUEL_MULTIPLIER) {}

    }
}
