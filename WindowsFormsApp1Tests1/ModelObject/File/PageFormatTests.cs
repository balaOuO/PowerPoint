using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1.ModelObject.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApp1.ModelObject.File.Tests
{
    [TestClass()]
    public class PageFormatTests
    {
        PageFormat _pageFormat;
        Shapes _shapes;
        string _jsonData;

        //TestPageFormat
        [TestInitialize()]
        [TestMethod()]
        public void TestPageFormat()
        {
            _shapes = new Shapes();
            _shapes.AddShape(ShapeName.LINE, new Point(1, 2), new Point(3, 4));
            _shapes.AddShapeToList();
            _shapes.AddShape(ShapeName.RECTANGLE, new Point(10, 20), new Point(30, 40));
            _shapes.AddShapeToList();
            _shapes.AddShape(ShapeName.ELLIPSE, new Point(100, 200), new Point(300, 400));
            _shapes.AddShapeToList();

            _pageFormat = new PageFormat(_shapes);
            _jsonData = JsonConvert.SerializeObject(_pageFormat);
            Assert.AreEqual(_jsonData, "{" + String.Format("\"ShapeList\":[{0},{1},{2}]" , JsonConvert.SerializeObject(new ShapeFormat(_shapes.ShapeList[0])) , JsonConvert.SerializeObject(new ShapeFormat(_shapes.ShapeList[1])) , JsonConvert.SerializeObject(new ShapeFormat(_shapes.ShapeList[2]))) + "}");
        }

        //TestRead
        [TestMethod()]
        public void TestRead()
        {
            PageFormat newPageFormat = JsonConvert.DeserializeObject<PageFormat>(_jsonData);
            Shapes newShapes = newPageFormat.Read();

            int index = 0;
            Assert.AreEqual(newShapes.ShapeList[index].ShapeName, _shapes.ShapeList[index].ShapeName);
            Assert.AreEqual(newShapes.ShapeList[index].Info, _shapes.ShapeList[index].Info);

            index = 1;
            Assert.AreEqual(newShapes.ShapeList[index].ShapeName, _shapes.ShapeList[index].ShapeName);
            Assert.AreEqual(newShapes.ShapeList[index].Info, _shapes.ShapeList[index].Info);

            index = 2;
            Assert.AreEqual(newShapes.ShapeList[index].ShapeName, _shapes.ShapeList[index].ShapeName);
            Assert.AreEqual(newShapes.ShapeList[index].Info, _shapes.ShapeList[index].Info);
        }
    }
}