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
    public class LineTests
    {
        //testShapeName
        [TestMethod()]
        public void TestShapeName()
        {
            Line line = new Line();

            Assert.AreEqual(line.ShapeName, ShapeName.LINE);
        }

        //testdraw
        [TestMethod()]
        public void TestDraw()
        {
            Line line = new Line();
            MockGraphicAdaptor mockGraphicAdaptor = new MockGraphicAdaptor();
            line.Draw(mockGraphicAdaptor);

            Assert.IsTrue(mockGraphicAdaptor.IsDrawLine);
        }
    }
}