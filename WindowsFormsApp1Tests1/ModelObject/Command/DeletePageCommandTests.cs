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
    public class DeletePageCommandTests
    {
        Model _model;
        ICommand _command;
        PrivateObject _commandPrivateObject;

        //TestDeletePageCommand
        [TestInitialize()]
        [TestMethod()]
        public void TestDeletePageCommand()
        {
            _model = new Model();
            _model.AddPage(0);
            _command = new DeletePageCommand(_model, 0);
            _commandPrivateObject = new PrivateObject(_command);
            Assert.AreEqual(_model.PageList.Count(), 2);
            Assert.AreEqual(_commandPrivateObject.GetFieldOrProperty("_shapes"), _model.PageList[0]);
        }

        //TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            _command.Execute();
            Assert.AreEqual(_model.PageList.Count(), 1);
            Assert.AreNotEqual(_commandPrivateObject.GetFieldOrProperty("_shapes"), _model.PageList[0]);
        }

        //TestRollBackExecute
        [TestMethod()]
        public void TestRollBackExecute()
        {
            _command.Execute();
            _command.RollBackExecute();
            Assert.AreEqual(_model.PageList.Count(), 2);
            Assert.AreEqual(_commandPrivateObject.GetFieldOrProperty("_shapes"), _model.PageList[0]);
        }
    }
}