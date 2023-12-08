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
    public class CommandManagerTests
    {
        CommandManager _commandManager;
        PrivateObject _commandManagerPrivateObject;
        MockCommand _command1;
        MockCommand _command2;
        MockCommand _command3;

        //TestExecute
        [TestInitialize()]
        [TestMethod()]
        public void TestExecute()
        {
            _commandManager = new CommandManager();
            _command1 = new MockCommand();
            _command2 = new MockCommand();
            _command3 = new MockCommand();
            _commandManager.Execute(_command1);
            _commandManager.Execute(_command2);
            _commandManager.Execute(_command3);
            _commandManagerPrivateObject = new PrivateObject(_commandManager);

            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_undo")).Count, 3);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_redo")).Count, 0);
        }

        //TestUndo
        [TestMethod()]
        public void TestUndo()
        {
            _commandManager.Undo();
            Assert.AreEqual(_command3.ExecuteTime, 1);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_undo")).Count, 2);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_redo")).Count, 1);
            _commandManager.Undo();
            Assert.AreEqual(_command2.ExecuteTime, 1);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_undo")).Count, 1);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_redo")).Count, 2);
            _commandManager.Undo();
            Assert.AreEqual(_command1.ExecuteTime, 1);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_undo")).Count, 0);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_redo")).Count, 3);
        }

        //TestRedo
        [TestMethod()]
        public void TestRedo()
        {
            _commandManager.Undo();
            _commandManager.Undo();
            _commandManager.Undo();

            _commandManager.Redo();
            Assert.AreEqual(_command3.RollBackExecuteTime, 1);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_undo")).Count, 1);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_redo")).Count, 2);

            _commandManager.Redo();
            Assert.AreEqual(_command2.RollBackExecuteTime, 1);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_undo")).Count, 2);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_redo")).Count, 1);

            _commandManager.Redo();
            Assert.AreEqual(_command1.RollBackExecuteTime, 1);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_undo")).Count, 3);
            Assert.AreEqual(((Stack<ICommand>)_commandManagerPrivateObject.GetFieldOrProperty("_redo")).Count, 0);
        }
    }

    class MockCommand : ICommand
    {
        public int ExecuteTime
        {
            get; set;
        }

        public int RollBackExecuteTime
        {
            get; set;
        }

        //Execute
        public void Execute()
        {
            ExecuteTime++;
        }

        //RollBackExecute
        public void RollBackExecute()
        {
            RollBackExecuteTime++;
        }
    }
}