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
    public class ShapeFormatTests
    {
        Shape _shape;
        ShapeFormat _shapeFormat;
        string _jsonData;

        //TestShapeFormat
        [TestInitialize()]
        [TestMethod()]
        public void TestShapeFormat()
        {
            _shape = new Rectangle();
            _shape.SetPoint(new Point(10, 20), new Point(100, 200));
            _shapeFormat = new ShapeFormat(_shape);

            _jsonData = JsonConvert.SerializeObject(_shapeFormat);
            Assert.AreEqual(_jsonData, "{\"ShapeName\":\"矩形\",\"StartPointX\":10.0,\"StartPointY\":20.0,\"EndPointX\":100.0,\"EndPointY\":200.0}");
        }

        //TestRead
        [TestMethod()]
        public void TestRead()
        {
            ShapeFormat newShapeFormat = JsonConvert.DeserializeObject<ShapeFormat>(_jsonData);
            Shape newShape = newShapeFormat.Read();

            Assert.AreEqual(newShape.ShapeName, _shape.ShapeName);
            Assert.AreEqual(newShape.Info, _shape.Info);
        }
    }
}