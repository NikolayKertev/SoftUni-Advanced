using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TRUCK_CONSUMPTION_MULTIPLIER = 1.6;
        private const double TRUCK_REFUEL_MULTIPLIER = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, TRUCK_CONSUMPTION_MULTIPLIER, TRUCK_REFUEL_MULTIPLIER)
        {
        }
    }
}
