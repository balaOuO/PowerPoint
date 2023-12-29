using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1.ModelObject.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WindowsFormsApp1Tests1;

namespace WindowsFormsApp1.ModelObject.File.Tests
{
    [TestClass()]
    public class PowerPointFileFormatTests
    {
        Model _model;
        PowerPointFileFormat _powerPointFileFormat;
        string _jsonData;

        //TestPowerPointFileFormat
        [TestInitialize()]
        [TestMethod()]
        public void TestPowerPointFileFormat()
        {
            _model = new Model(new MockGoogleDriveManager());
            _model.AddShape(ShapeName.LINE, new Point(1, 2), new Point(3, 4));
            _model.AddPage(1);
            _model.AddShape(ShapeName.LINE, new Point(10, 20), new Point(30, 40));
            _model.AddPage(0);

            _powerPointFileFormat = new PowerPointFileFormat(_model.PageList);
            _jsonData = JsonConvert.SerializeObject(_powerPointFileFormat);
            Assert.AreEqual(_jsonData , "{" + String.Format("\"PageList\":[{0},{1},{2}]", JsonConvert.SerializeObject(new PageFormat(_model.PageList[0])), JsonConvert.SerializeObject(new PageFormat(_model.PageList[1])), JsonConvert.SerializeObject(new PageFormat(_model.PageList[2]))) + "}");
        }

        //TestRead
        [TestMethod()]
        public void TestRead()
        {
            PowerPointFileFormat newPowerPointFileFormat = JsonConvert.DeserializeObject<PowerPointFileFormat>(_jsonData);
            List<Shapes> newPageList = newPowerPointFileFormat.Read();

            Assert.AreEqual(newPageList.Count, _model.PageList.Count);

            int index = 0;
            Assert.AreEqual(newPageList[index].ShapeList.Count, _model.PageList[index].ShapeList.Count);

            index = 1;
            Assert.AreEqual(newPageList[index].ShapeList.Count, _model.PageList[index].ShapeList.Count);
            Assert.AreEqual(newPageList[index].ShapeList[0].ShapeName, _model.PageList[index].ShapeList[0].ShapeName);
            Assert.AreEqual(newPageList[index].ShapeList[0].Info, _model.PageList[index].ShapeList[0].Info);

            index = 2;
            Assert.AreEqual(newPageList[index].ShapeList.Count, _model.PageList[index].ShapeList.Count);
            Assert.AreEqual(newPageList[index].ShapeList[0].ShapeName, _model.PageList[index].ShapeList[0].ShapeName);
            Assert.AreEqual(newPageList[index].ShapeList[0].Info, _model.PageList[index].ShapeList[0].Info);
        }
    }
}