using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;
        private Smartphone smartphone;
        private int maximumCharge = 500;
        private int capacity = 3;
        private string model = "nokia";

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(model, maximumCharge);
            shop = new Shop(capacity);
        }

        [Test]
        public void Test_Ctor()
        {
            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void Test_Capacity_Setter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(-5);
            });
        }
        [Test]
        public void Test_Add_Should_Work()
        {
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void Test_Add_ShouldThrow_Phone_Already_Added()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone(model, 1));
            });
        }
        [Test]
        public void Test_Add_ShouldThrow_OverFlow_Capacity()
        {
            shop.Add(new Smartphone("1", 1));
            shop.Add(new Smartphone("2", 1));
            shop.Add(new Smartphone("3", 1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("4", 1));
            });
        }
        [Test]
        public void Test_Remove_Should_Work()
        {
            shop.Add(smartphone);

            shop.Remove(model);

            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void Test_Remove_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("non exis");
            });
        }
        [Test]
        public void Test_TestPhone_Should_Work()
        {
            shop.Add(smartphone);

            shop.TestPhone(model, 50);

            Assert.AreEqual(maximumCharge - 50, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void Test_TestPhone_ShoulThrow_MissingPhone()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("non exis", 10);
            });
        }
        [Test]
        public void Test_TestPhone_ShoulThrow_NotAble_ToTest()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(model, maximumCharge + 1);
            });
        }
        [Test]
        public void Test_ChargePhone_ShoulThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("non exis");
            });
        }
        [Test]
        public void Test_ChargePhone_Should_Work()
        {
            shop.Add(smartphone);

            shop.TestPhone(model, 50);

            shop.ChargePhone(model);

            Assert.AreEqual(maximumCharge, smartphone.CurrentBateryCharge);
        }
    }
}