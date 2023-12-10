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
    public class PointFactoryTests
    {
        [TestMethod()]
        public void TestCreatePoint()
        {
            PointFactory pointFactory = new PointFactory();
            PrivateObject privateObject = new PrivateObject(pointFactory);
            MockRandom mockrandom = new MockRandom();

            privateObject.SetFieldOrProperty("_random", mockrandom);
            string answerPointString = "(1600,900)";
            Assert.AreEqual(pointFactory.GetPoint().ToString(), answerPointString);
        }
    }
}