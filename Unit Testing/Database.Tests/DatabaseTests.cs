namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase()]
        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Constructor_Should_Work_With_Correct_Data(params int[] data)
        {
            var db = new Database(data);
            int expectedCount = data.Length;

            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
            CollectionAssert.AreEqual(data, db.Fetch());
        }

        [TestCase(1)]
        public void Add_Method_Should_Work_With_Correct_Data(int count)
        { 
            Database db = new Database();

            int expectedCount = 0;
            int[] expectedArray = new int[count];

            for (int i = 0; i < count; i++)
            {
                db.Add(i);

                expectedCount++;
                expectedArray[i] = i;
            }

            int actualCount = db.Count;
            var actualArray = db.Fetch();

            Assert.AreEqual(expectedCount, actualCount);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Add_Method_Should_Throw(params int[] data)
        {
            Database db = new Database(data);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(0);
            }, "You have exceeded the limit of the array!");
        }

        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Remove_Method_Should_Work_With_Correct_Data(params int[] data)
        {
            Database db = new Database(data);

            db.Remove();

            int expectedCount = data.Length - 1;
            int actualCount = db.Count;

            int expectedLastElement = data[data.Length - 2];

            var array = db.Fetch();
            int actualLastElement = array[actualCount - 1];

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedLastElement, actualLastElement);
        }

        [Test]
        public void Remove_Method_Should_Throw()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [TestCase()]
        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Fetch_Method_Should_Work_With_Correct_Data(params int[] data)
        {
            Database db = new Database(data);

            var actualArray = db.Fetch();

            int actualCount = actualArray.Length;

            var expectedArray = data;
            var expectedCount = data.Length;

            Assert.AreEqual(expectedCount, actualCount);
            CollectionAssert.AreEquivalent(expectedArray, actualArray);
        }
    }
}
