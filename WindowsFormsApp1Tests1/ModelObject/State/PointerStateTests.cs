using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1.ModelObject.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1Tests1;

namespace WindowsFormsApp1.ModelObject.State.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        Model _model;
        MockShapes _mockShapes;
        ICanvasState _canvasState;
        bool _isNotifyDataChange;
        PrivateObject _canvasStatePrivateObject;

        //HandleShapeDataChanged
        public void HandleShapeDataChanged()
        {
            _isNotifyDataChange = true;
        }

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _isNotifyDataChange = false;

            _model = new Model();
            _mockShapes = new MockShapes();

            _model.Shapes = _mockShapes;
            _mockShapes.AddShape(ShapeName.LINE, new Point(20, 20), new Point(40, 40));
            _mockShapes.AddShapeToList();
            _model._shapeDataChanged += HandleShapeDataChanged;

            _canvasState = new PointerState(_model);
            _canvasStatePrivateObject = new PrivateObject(_canvasState);
        }

        //TestPointerState
        [TestMethod()]
        public void TestPointerState()
        {
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_model"), _model);
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_startPoint").ToString(), "(0,0)");
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_endPoint").ToString(), "(0,0)");
        }

        //TestGetStateName
        [TestMethod()]
        public void TestGetStateName()
        {
            Assert.AreEqual(_canvasState.GetStateName(), "PointerState");
        }

        //TestMove
        [TestMethod()]
        public void TestMove()
        {
            _canvasState.Move(new Point(1, 2));
            Assert.IsFalse(_mockShapes.IsMoveShape);
            Assert.AreEqual(_mockShapes.MoveInput, string.Empty);
            Assert.IsFalse(_isNotifyDataChange);
            Assert.IsFalse((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_startPoint").ToString(), "(0,0)");
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_endPoint").ToString(), "(0,0)");

            Initialize();
            _canvasState.Press(new Point(30, 30));
            _isNotifyDataChange = false;
            _canvasState.Move(new Point(31, 32));
            Assert.IsTrue(_mockShapes.IsMoveShape);
            Assert.AreEqual(_mockShapes.MoveInput, "(1,2)");
            Assert.IsTrue(_isNotifyDataChange);
            Assert.IsTrue((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_startPoint").ToString(), "(31,32)");
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_endPoint").ToString(), "(31,32)");

            _isNotifyDataChange = false;
            _mockShapes.IsMoveShape = false;
            _canvasState.Move(new Point(29, 28));
            Assert.IsTrue(_mockShapes.IsMoveShape);
            Assert.AreEqual(_mockShapes.MoveInput, "(-2,-4)");
            Assert.IsTrue(_isNotifyDataChange);
            Assert.IsTrue((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_startPoint").ToString(), "(29,28)");
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_endPoint").ToString(), "(29,28)");
        }

        //TestPress
        [TestMethod()]
        public void TestPress()
        {
            _canvasState.Press(new Point(1, 2));
            Assert.IsFalse(_isNotifyDataChange);
            Assert.IsTrue(_mockShapes.IsSelectShape);
            Assert.IsTrue((bool) _canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_startPoint").ToString(), "(1,2)");
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_endPoint").ToString(), "(0,0)");

            Initialize();
            _canvasState.Press(new Point(30, 30));
            Assert.IsTrue(_isNotifyDataChange);
            Assert.IsTrue(_mockShapes.IsSelectShape);
            Assert.IsTrue((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_startPoint").ToString(), "(30,30)");
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_endPoint").ToString(), "(0,0)");

            Initialize();
            _canvasState.Press(new Point(1, 2));
            _isNotifyDataChange = false;
            _mockShapes.IsSelectShape = false;
            _canvasState.Press(new Point(3, 4));
            Assert.IsFalse(_isNotifyDataChange);
            Assert.IsFalse(_mockShapes.IsSelectShape);
            Assert.IsTrue((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_startPoint").ToString(), "(1,2)");
            Assert.AreEqual(_canvasStatePrivateObject.GetFieldOrProperty("_endPoint").ToString(), "(0,0)");
        }

        //TestRelease
        [TestMethod()]
        public void TestRelease()
        {
            _canvasState.Release();
            Assert.IsFalse((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));

            Initialize();
            _canvasState.Press(new Point(30, 30));
            _canvasState.Release();
            Assert.IsFalse((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            _canvasState.Move(new Point(1, 1));
            Assert.IsFalse(_mockShapes.IsMoveShape);
        }
    }
}