using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesLib;
using Lab12;

namespace Lab12_HTable_TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LPoint_ConstructorTest()
        {
            Shape shape = new Shape("1");
            LPoint<Shape> point = new LPoint<Shape>(shape);

            Assert.IsTrue(point.value.Equals(shape));
        }

        [TestMethod]
        public void HTable_ConstructorTest()
        {
            HTable<Shape> table = new HTable<Shape>(3);

            Assert.AreEqual(table.Size, 3);
        }

        [TestMethod]
        public void HTable_Add_NullPointTest()
        {
            HTable<Shape> table = new HTable<Shape>(1);
            Shape shape = new Shape("1");
            table.Add(shape);

            Assert.IsNotNull(table[0]);
        }

        [TestMethod]
        public void HTable_Add_ChainingTest()
        {
            HTable<Shape> table = new HTable<Shape>(1);
            Shape shape = new Shape("1");
            table.Add(shape);
            table.Add(shape);
            table.Add(shape);

            Assert.IsNotNull(table[0].next);
        }

        [TestMethod]
        public void HTable_Delete_PointTest()
        {
            HTable<Shape> table = new HTable<Shape>(1);
            Shape shape = new Shape("1");
            table.Add(shape);
            table.Delete(shape);

            Assert.IsNull(table[0]);
        }

        [TestMethod]
        public void HTable_Delete_NullTest()
        {
            HTable<Shape> table = new HTable<Shape>(1);
            Shape shape = new Shape("1");
            table.Delete(shape);

            Assert.IsNull(table[0]);
        }

        [TestMethod]
        public void HTable_Delete_PointChainTest()
        {
            HTable<Shape> table = new HTable<Shape>(1);
            Shape shape1 = new Shape("1");
            Shape shape2 = new Shape("2");
            table.Add(shape1);
            table.Add(shape1);
            table.Add(shape2);
            table.Delete(shape2);

            Assert.IsNull(table[0].next.next);
        }
    }
}
