namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "Audi";
        private const string Model = "A4";
        private const double FuelComsumption = 4.5;
        private const double FuelCapacity = 120.5;
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car(Make, Model, FuelComsumption, FuelCapacity);
        }

        [Test]
        public void Constructor_Should_Work_With_Correct_Data()
        {
            string expectedMake = Make;
            string expectedModel = Model;
            double expectedFuelConsump = FuelComsumption;
            double expectedFuelCapacity = FuelCapacity;
            double expectedFuelAmmount = 0;

            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsump = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;
            double actualFuelAmmount = car.FuelAmount;

            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedFuelConsump, actualFuelConsump);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
            Assert.AreEqual(expectedFuelAmmount, actualFuelAmmount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Make_Should_Throw_Exception_Null_Or_Empty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(make, Model, FuelComsumption, FuelCapacity);
            });
        }

        [TestCase("")]
        [TestCase(null)]
        public void Model_Should_Throw_Exception_Null_Or_Empty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(Make, model, FuelComsumption, FuelCapacity);
            });
        }

        [TestCase(0)]
        [TestCase(-50)]
        [TestCase(-1)]
        public void FuelConsumption_Should_Throw_Exception_0_Or_Negative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(Make, Model, fuelConsumption, FuelCapacity);
            });
        }

        [TestCase(0)]
        [TestCase(-50)]
        [TestCase(-1)]
        public void FuelCapacity_Should_Throw_Exception_0_Or_Negative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(Make, Model, FuelComsumption, fuelCapacity);
            });
        }

        [Test]
        public void Refuel_Method_Should_Work_With_Correct_Data()
        {
            car.Refuel(50);

            double expectedFuelAmmount = 0 + car.FuelAmount;
            double actualFuelAmmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmmount, actualFuelAmmount);
        }

        [Test]
        public void Refuel_Method_Should_Work_When_Over_FuelCapacity()
        {
            car.Refuel(FuelCapacity + 50);

            double expectedFuelAmmount = FuelCapacity;
            double actualFuelAmmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmmount, actualFuelAmmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void Refuel_Method_Should_Throw_Exception_When_Fuel_Below_Or_Equal_To_0(double fuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuel);
            });
        }

        [Test]
        public void Drive_Method_Should_Work_With_Correct_Data()
        {
            // fuelNeeded = (distance / 100) * this.FuelConsumption;
            car.Refuel(50);
            car.Drive(100);

            double expectedFuelAmmount = 50 - 4.5;
            double actualFuelAmmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmmount, actualFuelAmmount);

        }

        [TestCase(100)]
        [TestCase(0.1)]
        public void Drive_Method_Should_Throw_Exception_When_FuelNeeded_Is_More_Than_FuelAmmount(double distance)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }
    }
}