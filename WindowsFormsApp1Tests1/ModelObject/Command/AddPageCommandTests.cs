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
    public class AddPageCommandTests
    {
        ICommand _command;
        Model _model;
        Shapes _shapes;

        //TestAddPageCommand
        [TestInitialize()]
        [TestMethod()]
        public void TestAddPageCommand()
        {
            _model = new Model();
            _shapes = new Shapes();
            _command = new AddPageCommand(_model, 1, _shapes);
        }

        //TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            _command.Execute();
            Assert.AreEqual(_model.PageList.Count() , 2);
        }

        //TestRollBackExecute
        [TestMethod()]
        public void TestRollBackExecute()
        {
            _command.Execute();
            _command.RollBackExecute();
            Assert.AreEqual(_model.PageList.Count(), 1);
        }
    }
}