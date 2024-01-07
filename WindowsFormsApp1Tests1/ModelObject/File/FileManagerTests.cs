using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.ModelObject.File;
using Newtonsoft.Json;
using WindowsFormsApp1Tests1;
using System.IO;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class FileManagerTests
    {
        Model _model;
        PowerPointFileFormat _powerPointFileFormat;
        string _jsonData;

        //TestPowerPointFileFormat
        [TestInitialize()]
        public void TestPowerPointFileFormat()
        {
            _model = new Model(new MockGoogleDriveManager());
            _model.AddShape(ShapeName.LINE, new Point(1, 2), new Point(3, 4));
            _model.AddPage(1);
            _model.AddShape(ShapeName.LINE, new Point(10, 20), new Point(30, 40));
            _model.AddPage(0);

            _powerPointFileFormat = new PowerPointFileFormat(_model.PageList);
            _jsonData = JsonConvert.SerializeObject(_powerPointFileFormat);
        }

        //TestSave
        [TestMethod()]
        public void TestSave()
        {
            FileManager.Save(_model.PageList);
            string fileData = File.ReadAllText(new ProjectFile().SaveFilePath + ProjectFile.SAVE_FILE_NAME);
            Assert.AreEqual(fileData, _jsonData);
        }

        //TestLoad
        [TestMethod()]
        public void TestLoad()
        {
            FileManager.Save(_model.PageList);
            string fileLoadData = JsonConvert.SerializeObject(new PowerPointFileFormat(FileManager.Load()));
            Assert.AreEqual(fileLoadData, _jsonData);
        }
    }
}