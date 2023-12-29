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
    public class MoveCommandTests
    {
        ICommand _command;
        Model _model;

        //TestMoveCommand
        [TestInitialize()]
        [TestMethod()]
        public void TestMoveCommand()
        {
            _model = new Model(new MockGoogleDriveManager());
            _command = new MoveCommand(_model , 0 , 0, new Point(100, 100), new Point(115, 115));
        }

        //TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            _model.AddShapeCommand(0 , ShapeName.ELLIPSE, new Point(10, 10), new Point(200, 200));
            _command.Execute();
            Assert.AreEqual(_model.ShapeList.Count , 1);
            Assert.AreEqual(_model.ShapeList[0].Info, "(25,25),(215,215)");
        }

        //TestExecute1
        [TestMethod()]
        public void TestExecute1()
        {
            _model.AddShapeCommand(0 , ShapeName.ELLIPSE, new Point(10, 10), new Point(100, 100));
            _command.Execute();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].Info, "(10,10),(115,115)");
        }

        //TestRollBackExecute
        [TestMethod()]
        public void TestRollBackExecute()
        {
            _model.AddShapeCommand(0 , ShapeName.ELLIPSE, new Point(10, 10), new Point(200, 200));
            _command.Execute();
            _command.RollBackExecute();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].Info, "(10,10),(200,200)");
        }

        //TestRollBackExecute1
        [TestMethod()]
        public void TestRollBackExecute1()
        {
            _model.AddShapeCommand(0 , ShapeName.ELLIPSE, new Point(10, 10), new Point(100, 100));
            _command.Execute();
            _command.RollBackExecute();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].Info, "(10,10),(100,100)");
        }
    }
}