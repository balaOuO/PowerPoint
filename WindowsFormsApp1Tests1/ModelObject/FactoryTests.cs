using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1Tests1;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class FactoryTests
    {
        PrivateObject _factpryPrivateObject;

        //testFactory
        [TestMethod()]
        public void TestFactory()
        {
            Factory factory = new Factory(new Random());
            _factpryPrivateObject = new PrivateObject(factory);

            Assert.IsTrue(_factpryPrivateObject.GetFieldOrProperty("_random") is Random);
        }

        //TestCreateShapes
        [TestMethod()]
        public void TestCreateShapes()
        {
            Assert.IsTrue(Factory.CreateShapes(ShapeName.RECTANGLE) is Rectangle);
            Assert.IsTrue(Factory.CreateShapes(ShapeName.LINE) is Line);
            Assert.IsTrue(Factory.CreateShapes(ShapeName.ELLIPSE) is Ellipse);
            Assert.IsTrue(Factory.CreateShapes("阿巴阿巴") == null);
        }

        //TestCreateRandomPoint
        [TestMethod()]
        public void TestCreateRandomPoint()
        {
            Factory factory = new Factory(new MockRandom());
            Point point = factory.CreateRandomPoint(10, 20);
            Assert.AreEqual(point.X, 10);
            Assert.AreEqual(point.Y, 20);
        }
    }
}