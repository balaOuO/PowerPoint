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
    public class DeleteShapeByIndexCommandTests
    {
        Model _model;
        ICommand _command;
        //TestDeleteShapeByIndexCommand
        [TestInitialize()]
        [TestMethod()]
        public void TestDeleteShapeByIndexCommand()
        {
            _model = new Model();
            _model.AddShapeCommand(0 , ShapeName.LINE, new Point(10, 10), new Point(20, 20));
            _command = new DeleteShapeByIndexCommand(_model, 0 , 0);
            Assert.AreEqual(_model.ShapeList.Count, 1);
        }

        //TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            _command.Execute();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }

        //TestRollBackExecute
        [TestMethod()]
        public void TestRollBackExecute()
        {
            _command.Execute();
            _command.RollBackExecute();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].ShapeName, ShapeName.LINE);
            Assert.AreEqual(_model.ShapeList[0].StartPoint.ToString(), "(10,10)");
            Assert.AreEqual(_model.ShapeList[0].EndPoint.ToString(), "(20,20)");
        }
    }
}