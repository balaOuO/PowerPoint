using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class PointTests
    {
        Point _point;

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _point = new Point(1.2, 3.456);
        }

        //PointTest
        [TestMethod()]
        public void TestPoint()
        {
            Assert.AreEqual(_point.X, 1.2);
            Assert.AreEqual(_point.Y, 3.456);
        }

        //testX
        [TestMethod()]
        public void TestX()
        {
            _point.X = 7.8;

            Assert.AreEqual(_point.X, 7.8);
        }

        //testY
        [TestMethod()]
        public void TestY()
        {
            _point.Y = 7.8;

            Assert.AreEqual(_point.Y, 7.8);
        }

        //ToStringTest
        [TestMethod()]
        public void TestToString()
        {
            Assert.AreEqual(_point.ToString(), "(1,3)");
        }

        //TestDistance
        [TestMethod()]
        public void TestDistance()
        {
            Assert.AreEqual(Point.CalculateDistance(new Point(0, 0), new Point(3, 4)), 5);
            Assert.AreEqual(Point.CalculateDistance(new Point(-2, -2), new Point(1, 2)), 5);
            Assert.AreEqual(Point.CalculateDistance(new Point(5, 7), new Point(5, 7)), 0);
            Assert.AreEqual(Point.CalculateDistance(new Point(-1, -1), new Point(-4, -5)), 5);
            Assert.AreEqual(Point.CalculateDistance(new Point(0.5, 0.5), new Point(3.5, 4.5)), 5);
        }
    }
}