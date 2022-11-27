using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double BUS_CONSUMPTION_MULTIPLIER = 1.4;
        private const double CAR_REFUEL_MULTIPLIER = 1;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, BUS_CONSUMPTION_MULTIPLIER, CAR_REFUEL_MULTIPLIER)
        {
        }

        public string DriveEmpty(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * FuelConsumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}

