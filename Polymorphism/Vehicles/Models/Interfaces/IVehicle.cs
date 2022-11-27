using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double ConsumptionMultiplier { get; }
        double RefuelMultiplier { get; }
        double TankCapacity { get; }

        string Drive(double distance);
        void Refuel(double fuel);
    }
}
