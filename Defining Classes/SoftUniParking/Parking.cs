using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new Dictionary<string, Car>();
            Capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }
        public  int Count
        {
            get { return cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public Car GetCar(string regNumber)
        {
            return cars[regNumber];
        }
        public string RemoveCar(string RegNumber)
        {
            if (!cars.ContainsKey(RegNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(RegNumber);
                return $"Successfully removed {RegNumber}";
            }
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {
                RemoveCar(number);
            }
        }
    }
}
