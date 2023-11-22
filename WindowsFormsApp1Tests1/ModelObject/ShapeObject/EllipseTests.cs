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
    public class EllipseTests
    {
        //testShapeName
        [TestMethod()]
        public void TestShapeName()
        {
            Ellipse ellipse = new Ellipse();

            Assert.AreEqual(ellipse.ShapeName, ShapeName.ELLIPSE);
        }

        //testdraw
        [TestMethod()]
        public void TestDraw()
        {
            Ellipse ellipse = new Ellipse();
            MockGraphicAdaptor mockGraphicAdaptor = new MockGraphicAdaptor();
            ellipse.Draw(mockGraphicAdaptor);

            Assert.IsTrue(mockGraphicAdaptor.IsDrawEllipse);
        }
    }
}