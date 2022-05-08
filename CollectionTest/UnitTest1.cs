using Collections;
using NUnit.Framework;
using System;
using System.Linq;

namespace CollectionTest
{
    public class Tests
    {
        private Collection<int> nums;

        [SetUp]
        public void Setup()
        {
            nums = new Collection<int>();
        }

        [Test]
        public void InitialTest()
        {
            Assert.IsNotNull(nums);

        }

        [Test]
        public void TestEmptyConstructor()
        {
            Assert.AreEqual(0, nums.Count);
            Assert.AreEqual(16, nums.Capacity);
            Assert.AreEqual(nums.ToString(), "[]");

        }

        [Test]
        public void TestAdd()
        {
            nums.Add(5);

            Assert.AreEqual(1, nums.Count);
            Assert.AreEqual(nums.ToString(),"[5]");
            Assert.AreEqual(16, nums.Capacity);
        }

        [Test]
        public void TestAddRange()
        {
            nums.AddRange(1,2,3);

            Assert.AreEqual(3, nums.Count);
            Assert.AreEqual(nums.ToString(), "[1, 2, 3]");
            Assert.AreEqual(16, nums.Capacity);
        }

        [Test]
        public void TestEnsureCapacityWithAddRange()
        {
            nums.AddRange(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            Assert.AreEqual(17, nums.Count);
            Assert.AreEqual(32, nums.Capacity);
        }


        [Test]
        public void TestInsertAtMiddle()
        {
            nums.AddRange(1, 2, 3, 4);
            nums.InsertAt(1,77);
            Assert.AreEqual(5, nums.Count);
            Assert.AreEqual(77, nums[1]);
        }

        [Test]
        public void TestInsertAtStart()
        {
            nums.AddRange(1, 2, 3, 4);
            nums.InsertAt(0, 77);
            Assert.AreEqual(5, nums.Count);
            Assert.AreEqual(77, nums[0]);
        }

        [Test]
        public void TestInsertAtEnd()
        {
            nums.AddRange(1, 2, 3, 4);
            nums.InsertAt(3, 77);
            Assert.AreEqual(5, nums.Count);
            Assert.AreEqual(77, nums[3]);
        }

        [Test]
        public void TestCheckRangeWithInsertAt()
        {
            nums.AddRange(1, 2, 3, 4);
            Assert.Throws<ArgumentOutOfRangeException>
            (() => nums.InsertAt(7, 77));
        }

        [Test]
        public void GetByIndexTest()
        {
            nums.AddRange(1, 2, 3);

            Assert.That(nums[1] == 2);
        }

        [Test]
        public void GetByInvalidIndex()
        {
            nums.AddRange(1, 2, 3);

            Assert.Throws<ArgumentOutOfRangeException>
              (() => nums[5]=1);
        }

        [Test]
        public void RemoveAtStart()
        {
            nums.AddRange(1, 2, 3);

            nums.RemoveAt(0);

            Assert.AreEqual("[2, 3]", nums.ToString());
        }

        [Test]
        public void RemoveAtMiddle()
        {
            nums.AddRange(1, 2, 3);

            nums.RemoveAt(1);

            Assert.AreEqual("[1, 3]", nums.ToString());
        }

        [Test]
        public void RemoveAtEnd()
        {
            nums.AddRange(1, 2, 3);

            nums.RemoveAt(2);

            Assert.AreEqual("[1, 2]", nums.ToString());
        }

        [Test]
        public void RemoveAtIvalidIndex()
        {
            nums.AddRange(1, 2, 3);

            Assert.Throws<ArgumentOutOfRangeException>
             (() => nums.RemoveAt(3));
        }

        [Test]
        public void ClearFunctionalityTest()
        {
            nums.AddRange(1, 2, 3);
            nums.Clear();

            Assert.IsTrue(nums.Count == 0);
            Assert.AreEqual(nums.ToString(), "[]");
        }

        [Test]
        public void TestExchangeInTheMiddle()
        {
            nums.AddRange(1, 2, 3, 4, 5);
            nums.Exchange(1,2);
            Assert.AreEqual(nums.ToString(), "[1, 3, 2, 4, 5]");
        }

        [Test]
        public void TestExhangeFirstWithLast()
        {
            nums.AddRange(1, 2, 3, 4, 5);
            nums.Exchange(0, 4);
            Assert.AreEqual(nums.ToString(), "[5, 2, 3, 4, 1]");
        }

        [Test]
        public void TestExhangeWithOneInvalidIndex()
        {
            nums.AddRange(1, 2, 3, 4, 5);
            Assert.Throws<ArgumentOutOfRangeException>
            (() => nums.Exchange(0, 5));
        }

        [Test]
        public void TestExhangeWithTwoInvalidIndex()
        {
            nums.AddRange(1, 2, 3, 4, 5);
            Assert.Throws<ArgumentOutOfRangeException>
            (() => nums.Exchange(-1, 5));
        }

        [Test]
        public void TestWithOneMillion()
        {
            nums.AddRange(Enumerable.Range(1, 1000000).ToArray());
            Assert.AreEqual(1000000, nums.Count);
        }

    }
}