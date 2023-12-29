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
    public class AddShapeCommandTests
    {
        ICommand _command;
        Model _model;


        //TestAddShapeCommand
        [TestInitialize()]
        [TestMethod()]
        public void TestAddShapeCommand()
        {
            _model = new Model(new MockGoogleDriveManager());
            _command = new AddShapeCommand(_model, 0 , ShapeName.RECTANGLE, new Point(10, 10), new Point(20, 20));
        }

        //TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            _command.Execute();
            Assert.AreEqual(_model.ShapeList[0].ShapeName, ShapeName.RECTANGLE);
            Assert.AreEqual(_model.ShapeList[0].StartPoint.ToString(), "(10,10)");
            Assert.AreEqual(_model.ShapeList[0].EndPoint.ToString(), "(20,20)");
            Assert.AreEqual(_model.ShapeList.Count, 1);
        }

        //TestRollBackExecute
        [TestMethod()]
        public void TestRollBackExecute()
        {
            _command.Execute();
            _command.RollBackExecute();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }
    }
}