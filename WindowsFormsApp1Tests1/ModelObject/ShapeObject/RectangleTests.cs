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
    public class RectangleTests
    {
        //testShapeName
        [TestMethod()]
        public void TestShapeName()
        {
            Rectangle rectangle = new Rectangle();

            Assert.AreEqual(rectangle.ShapeName, ShapeName.RECTANGLE);
        }

        //testdraw
        [TestMethod()]
        public void TestDraw()
        {
            Rectangle rectangle = new Rectangle();
            MockGraphicAdaptor mockGraphicAdaptor = new MockGraphicAdaptor();
            rectangle.Draw(mockGraphicAdaptor);

            Assert.IsTrue(mockGraphicAdaptor.IsDrawRectangle);
        }
    }
}