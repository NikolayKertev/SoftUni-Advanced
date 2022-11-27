namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Models.Interfaces;
    using Vehicles.Models;

    public class Engine : IEngine
    {
        IVehicle truck;
        IVehicle car;
        IVehicle bus;

        List<IVehicle> vehicles = new List<IVehicle>();

        public void Run()
        {
            car = CreateVehicles("car");
            truck = CreateVehicles("truck");
            bus = CreateVehicles("bus");

            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);

            int numberOfLines = int.Parse(Console.ReadLine());
            string input;

            while (numberOfLines-- != 0)
            {
                input = Console.ReadLine();

                try
                {
                    VehicleAction(input);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

        }

        private void VehicleAction(string input)
        {
            string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double ammount = double.Parse(cmdArgs[2]);

            switch (action)
            {
                case "Drive":
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(ammount));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(ammount));
                    }
                    else if (vehicleType == "Bus")
                    {
                        Console.WriteLine(bus.Drive(ammount));
                    }
                    break;
                case "Refuel":
                    if (vehicleType == "Car")
                    {
                        car.Refuel(ammount);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(ammount);
                    }
                    else if (vehicleType == "Bus")
                    {
                        bus.Refuel(ammount);
                    }
                    break;
                case "DriveEmpty":
                    if (vehicleType != "Bus")
                    {
                        break;
                    }

                    Bus tempBus = bus as Bus;

                    if (tempBus == null)
                    {
                        throw new ArgumentException("There's no such bus!");
                    }

                    Console.WriteLine(tempBus.DriveEmpty(ammount));
                    break;
            }
        }
        public IVehicle CreateVehicles(string type)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            IVehicle vehicle;

            switch (type)
            {
                case "car":
                    vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "truck":
                    vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "bus":
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                default:
                    vehicle = null;
                    break;
            }


            return vehicle;
        }
    }
}
