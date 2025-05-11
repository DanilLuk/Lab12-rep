using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab12;
using ShapesLib;

namespace Lab12_TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PointList_MakeList_InvalidLengthTest()
        {
            Point list = PointList.MakeList(0);
            Assert.IsNull(list);
        }

        [TestMethod]
        public void PointList_MakeList_ValidLengthTest()
        {
            Point list = PointList.MakeList(3);
            Assert.IsTrue(list is Point);
        }

        [TestMethod]
        public void PointList_PrintList_ExTest()
        {
            Point list = null;
            Assert.ThrowsException<NullReferenceException>(() => PointList.PrintList(list));
        }

        [TestMethod]
        public void PointList_AddPoint_Test() // проверяет факт добавления точки
        {
            Point list = PointList.MakeList(3);
            Point temp = (Point)list.next.Clone();
            list = PointList.AddPoint(list, 2);
            Assert.AreNotEqual(temp.data.Name, list.data.Name);
        }

        [TestMethod]
        public void PointList_AddPoint_EmptyListTest() // проверяет добавление точки в null
        {
            Point list = null;
            list = PointList.AddPoint(list, 4);
            Assert.IsTrue(list is Point);
        }

        [TestMethod]
        public void PointList_AddPoint_IndexOneTest() // проверяет добавление точки в начало
        {
            Point list = PointList.MakeList(3);
            Point newList = PointList.AddPoint(list, 1);
            Assert.AreNotSame(list, newList);
        }

        [TestMethod]
        public void PointList_AddPoint_IndexExceedingTest() // проверяет добавление точки с индексом больше длины
        {
            Point list = PointList.MakeList(1);
            Point temp = PointList.CloneList(list);
            list = PointList.AddPoint(list, 100);
            Assert.IsNull(list.next);
            Assert.IsNull(temp.next);
        }

        [TestMethod]
        public void PointList_RemovePoint_Test() // проверяет удаление точки (искомое имя в начале)
        {
            Point list = PointList.MakeList(5);
            String name = list.data.Name;
            Point temp = (Point)list.Clone();
            list = PointList.RemovePoint(list, name);
            Assert.AreNotEqual(temp.data.Name, list.data.Name);
        }

        [TestMethod]
        public void PointList_RemovePoint_Test2() // проверяет удаление точки (искомое имя не в начале)
        {
            Point list = PointList.MakeList(5);
            String name = list.next.data.Name;
            Point temp = (Point)list.next.Clone();
            list = PointList.RemovePoint(list, name);
            Assert.AreNotEqual(temp.data.Name, list.next.data.Name);
        }
    }
}
