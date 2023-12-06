using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _model = new Model();
            _command = new AddShapeCommand(_model, ShapeName.RECTANGLE, new Point(10, 10), new Point(20, 20));
        }

        [TestMethod()]
        public void TestExecute()
        {
            _command.Execute();
            Assert.AreEqual(_model.ShapeList[0].ShapeName, ShapeName.RECTANGLE);
            Assert.AreEqual(_model.ShapeList[0].StartPoint.ToString(), "(10,10)");
            Assert.AreEqual(_model.ShapeList[0].EndPoint.ToString(), "(20,20)");
            Assert.AreEqual(_model.ShapeList.Count, 1);
        }

        [TestMethod()]
        public void TestRollBackExecute()
        {
            _command.Execute();
            _command.RollBackExecute();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }
    }
}