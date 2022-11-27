namespace Vehicles.Models
{
    using System;
    using Vehicles.Models.Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double consumptionMultiplier, double refuelMultiplier)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            ConsumptionMultiplier = consumptionMultiplier;
            RefuelMultiplier = refuelMultiplier;
        }

        public double FuelQuantity 
        {
            get => fuelQuantity;
            protected set 
            {
                fuelQuantity = value;

                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
            } 
        }
        public double FuelConsumption { get; private set; }
        public double ConsumptionMultiplier { get; private set; }
        public double RefuelMultiplier { get; private set; }
        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            if (distance * (FuelConsumption + ConsumptionMultiplier) > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * (FuelConsumption + ConsumptionMultiplier);

            return $"{this.GetType().Name} travelled {distance} km";
        }
        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            double modifiedFuel = fuel * RefuelMultiplier;

            if (fuelQuantity + modifiedFuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            FuelQuantity += modifiedFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
